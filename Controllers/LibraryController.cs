using Microsoft.AspNetCore.Mvc;
using VisualizadorEstructuras.Models;
using Microsoft.EntityFrameworkCore;

namespace VisualizadorEstructuras.Controllers;

public class LibraryController : Controller
{
    private readonly AppDbContext _context;

    public LibraryController(AppDbContext context)
    {
        _context = context;
    }

    // Página principal de la biblioteca (Dashboard)
    public IActionResult Index()
    {
        var totalLibros = _context.Libros.Count();
        var librosDisponibles = _context.Libros.Count(l => l.Disponible);
        var librosPrestados = totalLibros - librosDisponibles;
        var totalCategorias = _context.Categorias.Count();
        var totalTransacciones = _context.Prestamos.Count();
        var reservasPendientes = _context.Reservas.Count(r => r.Activa);

        ViewBag.Estadisticas = new Dictionary<string, int>
        {
            { "TotalLibros", totalLibros },
            { "LibrosDisponibles", librosDisponibles },
            { "LibrosPrestados", librosPrestados },
            { "TotalTransacciones", totalTransacciones },
            { "ReservasPendientes", reservasPendientes },
            { "Categorias", totalCategorias }
        };
        ViewBag.Libros = _context.Libros.Include(l => l.Categoria).ToList();
        return View();
    }

    // Vista del catálogo (Lista Enlazada)
    public IActionResult Catalogo(string? buscarTitulo, string? buscarAutor, int? categoriaId)
    {
        var libros = _context.Libros.Include(l => l.Categoria).AsQueryable();
        
        if (!string.IsNullOrEmpty(buscarTitulo))
            libros = libros.Where(l => l.Titulo.Contains(buscarTitulo));
        if (!string.IsNullOrEmpty(buscarAutor))
            libros = libros.Where(l => l.Autor.Contains(buscarAutor));
        if (categoriaId.HasValue)
        {
            // Buscar libros en la categoría y sus subcategorías
            var categoriaIds = GetCategoriaIdsIncluyendoSubcategorias(categoriaId.Value);
            libros = libros.Where(l => categoriaIds.Contains(l.CategoriaId));
        }

        ViewBag.Libros = libros.ToList();
        ViewBag.Categorias = GetCategoriasJerarquicas();
        ViewBag.TipoEstructura = "Lista Enlazada";
        ViewBag.Descripcion = "El catálogo de libros se almacena en la base de datos.";
        return View("Catalog");
    }

    // Vista del historial de transacciones (Pila)
    public IActionResult HistorialTransacciones()
    {
        var prestamos = _context.Prestamos
            .Include(p => p.Libro)
                .ThenInclude(l => l.Categoria)
            .OrderByDescending(p => p.FechaPrestamo)
            .ToList();
        ViewBag.Transacciones = prestamos;
        ViewBag.TipoEstructura = "Pila (Stack)";
        ViewBag.Descripcion = "El historial de préstamos se almacena en la base de datos.";
        return View("TransactionHistory");
    }

    // Vista de reservas (Cola)
    public IActionResult Reservas()
    {
        var reservas = _context.Reservas
            .Include(r => r.Libro)
                .ThenInclude(l => l.Categoria)
            .OrderBy(r => r.FechaSolicitud)
            .ToList();
        ViewBag.Reservas = reservas;
        ViewBag.Libros = _context.Libros.Include(l => l.Categoria).ToList();
        ViewBag.TipoEstructura = "Cola (Queue)";
        ViewBag.Descripcion = "Las reservas se gestionan en la base de datos.";
        return View("Reservations");
    }

    // Vista de categorías (Árbol)
    public IActionResult Categorias()
    {
        var categorias = GetCategoriasJerarquicas();
        ViewBag.Categorias = categorias;
        ViewBag.TipoEstructura = "Árbol (Tree)";
        ViewBag.Descripcion = "Las categorías se gestionan en la base de datos.";
        return View("Categories");
    }

    // GET: Agregar libro
    [HttpGet]
    public IActionResult AgregarLibro()
    {
        ViewBag.Categorias = GetCategoriasJerarquicas();
        return View();
    }

    // POST: Agregar libro
    [HttpPost]
    public IActionResult AgregarLibro(Libro libro)
    {
        try
        {
            // Asegurar que el libro esté disponible por defecto
            libro.Disponible = true;
            libro.Stock = libro.Stock > 0 ? libro.Stock : 2; // Stock por defecto
            
            _context.Libros.Add(libro);
            var result = _context.SaveChanges();
            
            if (result > 0)
            {
                TempData["Mensaje"] = "Libro agregado correctamente.";
                TempData["TipoMensaje"] = "success";
                return RedirectToAction("Catalogo");
            }
            else
            {
                TempData["Mensaje"] = "Error: No se pudo guardar el libro.";
                TempData["TipoMensaje"] = "danger";
                ViewBag.Categorias = GetCategoriasJerarquicas();
                return View(libro);
            }
        }
        catch (Exception ex)
        {
            TempData["Mensaje"] = $"Error al guardar: {ex.Message}";
            TempData["TipoMensaje"] = "danger";
            ViewBag.Categorias = GetCategoriasJerarquicas();
            return View(libro);
        }
    }

    // GET: Editar libro
    [HttpGet]
    public IActionResult EditarLibro(int id)
    {
        var libro = _context.Libros.Include(l => l.Categoria).FirstOrDefault(l => l.Id == id);
        if (libro == null)
        {
            return NotFound();
        }
        ViewBag.Categorias = GetCategoriasJerarquicas();
        return View(libro);
    }

    // POST: Editar libro
    [HttpPost]
    public IActionResult EditarLibro(Libro libro)
    {
        _context.Libros.Update(libro);
        _context.SaveChanges();
        TempData["Mensaje"] = "Libro editado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Catalogo");
    }

    // POST: Eliminar libro
    [HttpPost]
    public IActionResult EliminarLibro(int id)
    {
        var libro = _context.Libros.Find(id);
        if (libro == null)
        {
            return NotFound();
        }
        _context.Libros.Remove(libro);
        _context.SaveChanges();
        TempData["Mensaje"] = "Libro eliminado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Catalogo");
    }

    // GET o POST: Eliminar libro (sin antiforgery)
    [HttpGet, HttpPost]
    public IActionResult EliminarLibroPost(int id)
    {
        var libro = _context.Libros.Find(id);
        if (libro == null)
        {
            return NotFound();
        }
        _context.Libros.Remove(libro);
        _context.SaveChanges();
        TempData["Mensaje"] = "Libro eliminado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Catalogo");
    }

    // GET: Detalles del libro
    [HttpGet]
    public IActionResult DetallesLibro(int id)
    {
        var libro = _context.Libros.Include(l => l.Categoria).FirstOrDefault(l => l.Id == id);
        if (libro == null)
        {
            return NotFound();
        }
        return View("DetallesLibro", libro);
    }

    // GET: Agregar categoría
    [HttpGet]
    public IActionResult AgregarCategoria()
    {
        ViewBag.CategoriasPadre = GetCategoriasJerarquicas();
        return View();
    }

    // POST: Agregar categoría
    [HttpPost]
    public IActionResult AgregarCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        TempData["Mensaje"] = "Categoría agregada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Categorias");
    }

    // GET: Editar categoría
    [HttpGet]
    public IActionResult EditarCategoria(int id)
    {
        var categoria = _context.Categorias.Include(c => c.CategoriaPadre).FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }
        ViewBag.CategoriasPadre = GetCategoriasJerarquicas().Where(c => c.Id != id).ToList();
        return View(categoria);
    }

    // POST: Editar categoría
    [HttpPost]
    public IActionResult EditarCategoria(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        _context.SaveChanges();
        TempData["Mensaje"] = "Categoría editada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Categorias");
    }

    // GET o POST: Eliminar categoría
    [HttpGet, HttpPost]
    public IActionResult EliminarCategoria(int id)
    {
        var categoria = _context.Categorias.Include(c => c.Subcategorias).Include(c => c.Libros).FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }

        // Verificar si tiene subcategorías o libros
        if (categoria.Subcategorias.Any() || categoria.Libros.Any())
        {
            TempData["Mensaje"] = "No se puede eliminar una categoría que tiene subcategorías o libros.";
            TempData["TipoMensaje"] = "danger";
            return RedirectToAction("Categorias");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        TempData["Mensaje"] = "Categoría eliminada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Categorias");
    }

    // POST: Eliminar categoría (sin antiforgery)
    [HttpPost]
    public IActionResult EliminarCategoriaPost(int id)
    {
        var categoria = _context.Categorias.Include(c => c.Subcategorias).Include(c => c.Libros).FirstOrDefault(c => c.Id == id);
        if (categoria == null)
        {
            return NotFound();
        }

        // Verificar si tiene subcategorías o libros
        if (categoria.Subcategorias.Any() || categoria.Libros.Any())
        {
            TempData["Mensaje"] = "No se puede eliminar una categoría que tiene subcategorías o libros.";
            TempData["TipoMensaje"] = "danger";
            return RedirectToAction("Categorias");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        TempData["Mensaje"] = "Categoría eliminada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Categorias");
    }

    // GET: Detalles de categoría
    [HttpGet]
    public IActionResult DetallesCategoria(int id)
    {
        var categoria = _context.Categorias
            .Include(c => c.CategoriaPadre)
            .Include(c => c.Subcategorias)
            .Include(c => c.Libros)
            .FirstOrDefault(c => c.Id == id);
        
        if (categoria == null)
        {
            return NotFound();
        }
        return View("DetallesCategoria", categoria);
    }

    // Métodos auxiliares para manejar la jerarquía de categorías
    private List<Categoria> GetCategoriasJerarquicas()
    {
        var categorias = _context.Categorias
            .Include(c => c.CategoriaPadre)
            .Include(c => c.Subcategorias)
            .ToList();

        return categorias.Where(c => c.CategoriaPadreId == null).ToList();
    }

    private List<int> GetCategoriaIdsIncluyendoSubcategorias(int categoriaId)
    {
        var categoriaIds = new List<int> { categoriaId };
        var categoria = _context.Categorias
            .Include(c => c.Subcategorias)
            .FirstOrDefault(c => c.Id == categoriaId);

        if (categoria != null)
        {
            foreach (var subcategoria in categoria.Subcategorias)
            {
                categoriaIds.AddRange(GetCategoriaIdsIncluyendoSubcategorias(subcategoria.Id));
            }
        }

        return categoriaIds;
    }

    // GET: Agregar reserva
    [HttpGet]
    public IActionResult AgregarReserva()
    {
        ViewBag.Libros = _context.Libros.Where(l => l.Disponible).ToList();
        return View();
    }

    // POST: Agregar reserva
    [HttpPost]
    public IActionResult AgregarReserva(Reserva reserva)
    {
        reserva.FechaSolicitud = DateTime.Now;
        reserva.FechaExpiracion = DateTime.Now.AddDays(7);
        reserva.Activa = true;
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
        TempData["Mensaje"] = "Reserva agregada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Reservas");
    }

    // GET: Editar reserva
    [HttpGet]
    public IActionResult EditarReserva(int id)
    {
        var reserva = _context.Reservas.Include(r => r.Libro).FirstOrDefault(r => r.Id == id);
        if (reserva == null)
        {
            return NotFound();
        }
        ViewBag.Libros = _context.Libros.ToList();
        return View(reserva);
    }

    // POST: Editar reserva
    [HttpPost]
    public IActionResult EditarReserva(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
        _context.SaveChanges();
        TempData["Mensaje"] = "Reserva editada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Reservas");
    }

    // GET o POST: Eliminar reserva
    [HttpGet, HttpPost]
    public IActionResult EliminarReserva(int id)
    {
        var reserva = _context.Reservas.Find(id);
        if (reserva == null)
        {
            return NotFound();
        }
        _context.Reservas.Remove(reserva);
        _context.SaveChanges();
        TempData["Mensaje"] = "Reserva eliminada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Reservas");
    }

    // GET: Prestar libro
    [HttpGet]
    public IActionResult PrestarLibro()
    {
        ViewBag.Libros = _context.Libros.Where(l => l.Disponible).ToList();
        return View();
    }

    // POST: Prestar libro
    [HttpPost]
    public IActionResult PrestarLibro(Prestamo prestamo)
    {
        prestamo.FechaPrestamo = DateTime.Now;
        prestamo.Tipo = TipoPrestamo.Prestamo;
        _context.Prestamos.Add(prestamo);
        
        // Actualizar disponibilidad del libro
        var libro = _context.Libros.Find(prestamo.LibroId);
        if (libro != null)
        {
            libro.Disponible = false;
            libro.Stock--;
        }
        
        _context.SaveChanges();
        TempData["Mensaje"] = "Libro prestado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("HistorialTransacciones");
    }

    // GET: Editar préstamo
    [HttpGet]
    public IActionResult EditarPrestamo(int id)
    {
        var prestamo = _context.Prestamos.Include(p => p.Libro).FirstOrDefault(p => p.Id == id);
        if (prestamo == null)
        {
            return NotFound();
        }
        ViewBag.Libros = _context.Libros.ToList();
        return View(prestamo);
    }

    // POST: Editar préstamo
    [HttpPost]
    public IActionResult EditarPrestamo(Prestamo prestamo)
    {
        _context.Prestamos.Update(prestamo);
        _context.SaveChanges();
        TempData["Mensaje"] = "Préstamo editado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("HistorialTransacciones");
    }

    // GET o POST: Eliminar préstamo
    [HttpGet, HttpPost]
    public IActionResult EliminarPrestamo(int id)
    {
        var prestamo = _context.Prestamos.Find(id);
        if (prestamo == null)
        {
            return NotFound();
        }
        _context.Prestamos.Remove(prestamo);
        _context.SaveChanges();
        TempData["Mensaje"] = "Préstamo eliminado correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("HistorialTransacciones");
    }

    // POST: Devolver libro
    [HttpPost]
    public IActionResult DevolverLibro(int id)
    {
        var prestamo = _context.Prestamos.Find(id);
        if (prestamo == null)
        {
            return NotFound();
        }
        prestamo.FechaDevolucion = DateTime.Now;
        prestamo.Tipo = TipoPrestamo.Devolucion;
        
        // Actualizar disponibilidad del libro
        var libro = _context.Libros.Find(prestamo.LibroId);
        if (libro != null)
        {
            libro.Disponible = true;
            libro.Stock++;
        }
        
        _context.SaveChanges();
        TempData["Mensaje"] = "Libro devuelto correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("HistorialTransacciones");
    }

    // GET: Obtener estadísticas para AJAX
    [HttpGet]
    public JsonResult ObtenerEstadisticas()
    {
        var totalLibros = _context.Libros.Count();
        var librosDisponibles = _context.Libros.Count(l => l.Disponible);
        var librosPrestados = totalLibros - librosDisponibles;
        var totalCategorias = _context.Categorias.Count();
        var totalTransacciones = _context.Prestamos.Count();
        var reservasPendientes = _context.Reservas.Count(r => r.Activa);

        return Json(new
        {
            TotalLibros = totalLibros,
            LibrosDisponibles = librosDisponibles,
            LibrosPrestados = librosPrestados,
            TotalTransacciones = totalTransacciones,
            ReservasPendientes = reservasPendientes,
            Categorias = totalCategorias
        });
    }

    // POST: Eliminar transacción (sin antiforgery)
    [HttpPost]
    public IActionResult EliminarTransaccionPost(int id)
    {
        var prestamo = _context.Prestamos.Find(id);
        if (prestamo == null)
        {
            return NotFound();
        }
        _context.Prestamos.Remove(prestamo);
        _context.SaveChanges();
        TempData["Mensaje"] = "Transacción eliminada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("HistorialTransacciones");
    }

    // POST: Eliminar reserva (sin antiforgery)
    [HttpPost]
    public IActionResult EliminarReservaPost(int id)
    {
        var reserva = _context.Reservas.Find(id);
        if (reserva == null)
        {
            return NotFound();
        }
        _context.Reservas.Remove(reserva);
        _context.SaveChanges();
        TempData["Mensaje"] = "Reserva eliminada correctamente.";
        TempData["TipoMensaje"] = "success";
        return RedirectToAction("Reservas");
    }
} 