using Microsoft.EntityFrameworkCore;

namespace VisualizadorEstructuras.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relaciones jerárquicas de categorías
        modelBuilder.Entity<Categoria>()
            .HasOne(c => c.CategoriaPadre)
            .WithMany(c => c.Subcategorias)
            .HasForeignKey(c => c.CategoriaPadreId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurar relación entre Libro y Categoria
        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Categoria)
            .WithMany(c => c.Libros)
            .HasForeignKey(l => l.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Categorías principales (raíz)
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Ficción", Descripcion = "Libros de narrativa ficticia" },
            new Categoria { Id = 2, Nombre = "No Ficción", Descripcion = "Libros basados en hechos reales" },
            new Categoria { Id = 3, Nombre = "Académico", Descripcion = "Libros de estudio y referencia" }
        );

        // Subcategorías de Ficción
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 4, Nombre = "Novela", Descripcion = "Novelas literarias", CategoriaPadreId = 1 },
            new Categoria { Id = 5, Nombre = "Ciencia Ficción", Descripcion = "Ciencia ficción y fantasía", CategoriaPadreId = 1 },
            new Categoria { Id = 6, Nombre = "Misterio", Descripcion = "Novelas de misterio y suspense", CategoriaPadreId = 1 }
        );

        // Subcategorías de No Ficción
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 7, Nombre = "Historia", Descripcion = "Libros de historia", CategoriaPadreId = 2 },
            new Categoria { Id = 8, Nombre = "Biografía", Descripcion = "Biografías y autobiografías", CategoriaPadreId = 2 },
            new Categoria { Id = 9, Nombre = "Ciencia", Descripcion = "Libros de divulgación científica", CategoriaPadreId = 2 }
        );

        // Subcategorías de Académico
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 10, Nombre = "Matemáticas", Descripcion = "Libros de matemáticas", CategoriaPadreId = 3 },
            new Categoria { Id = 11, Nombre = "Física", Descripcion = "Libros de física", CategoriaPadreId = 3 },
            new Categoria { Id = 12, Nombre = "Química", Descripcion = "Libros de química", CategoriaPadreId = 3 }
        );

        // Libros (distribuidos en subcategorías)
        modelBuilder.Entity<Libro>().HasData(
            // Novela (Ficción)
            new Libro { Id = 1, Titulo = "Cien Años de Soledad", Autor = "Gabriel García Márquez", ISBN = "978-0307474728", Anio = 1967, CategoriaId = 4, Disponible = true, Stock = 2 },
            new Libro { Id = 2, Titulo = "Rayuela", Autor = "Julio Cortázar", ISBN = "978-8437604947", Anio = 1963, CategoriaId = 4, Disponible = true, Stock = 2 },
            
            // Ciencia Ficción (Ficción)
            new Libro { Id = 3, Titulo = "Dune", Autor = "Frank Herbert", ISBN = "978-0441172719", Anio = 1965, CategoriaId = 5, Disponible = true, Stock = 2 },
            new Libro { Id = 4, Titulo = "El Aleph", Autor = "Jorge Luis Borges", ISBN = "978-8426404187", Anio = 1949, CategoriaId = 5, Disponible = true, Stock = 2 },
            
            // Historia (No Ficción)
            new Libro { Id = 5, Titulo = "Sapiens", Autor = "Yuval Noah Harari", ISBN = "978-8499924213", Anio = 2011, CategoriaId = 7, Disponible = true, Stock = 2 },
            new Libro { Id = 6, Titulo = "Breves respuestas a las grandes preguntas", Autor = "Stephen Hawking", ISBN = "978-8491392065", Anio = 2018, CategoriaId = 7, Disponible = true, Stock = 2 },
            
            // Ciencia (No Ficción)
            new Libro { Id = 7, Titulo = "El diario de Ana Frank", Autor = "Ana Frank", ISBN = "978-8497593794", Anio = 1947, CategoriaId = 9, Disponible = true, Stock = 2 },
            new Libro { Id = 8, Titulo = "Los cuatro acuerdos", Autor = "Miguel Ruiz", ISBN = "978-1878424310", Anio = 1997, CategoriaId = 9, Disponible = true, Stock = 2 },
            
            // Matemáticas (Académico)
            new Libro { Id = 9, Titulo = "Álgebra de Baldor", Autor = "Aurelio Baldor", ISBN = "978-9702602532", Anio = 1941, CategoriaId = 10, Disponible = true, Stock = 2 },
            new Libro { Id = 10, Titulo = "Cálculo", Autor = "James Stewart", ISBN = "978-6074817448", Anio = 2008, CategoriaId = 10, Disponible = true, Stock = 2 },
            
            // Física (Académico)
            new Libro { Id = 11, Titulo = "Física Universitaria", Autor = "Sears y Zemansky", ISBN = "978-6073223493", Anio = 2018, CategoriaId = 11, Disponible = true, Stock = 2 },
            new Libro { Id = 12, Titulo = "Química", Autor = "Raymond Chang", ISBN = "978-6071509636", Anio = 2010, CategoriaId = 12, Disponible = true, Stock = 2 }
        );
    }
} 