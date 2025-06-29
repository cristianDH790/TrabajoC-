using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualizadorEstructuras.Models;

public class Libro
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; } = string.Empty;
    [Required]
    public string Autor { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? Anio { get; set; }
    public string? Descripcion { get; set; }
    
    // Relación con categoría
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public virtual Categoria Categoria { get; set; } = null!;
    
    // Propiedad calculada para compatibilidad
    public string CategoriaNombre => Categoria?.Nombre ?? string.Empty;
    
    public bool Disponible { get; set; } = true;
    public DateTime? FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public string? NombreUsuario { get; set; }
    public int Stock { get; set; } = 2;
} 