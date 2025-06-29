using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualizadorEstructuras.Models;

public class Prestamo
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int LibroId { get; set; }
    [ForeignKey("LibroId")]
    public Libro Libro { get; set; } = null!;
    [Required]
    public string NombreUsuario { get; set; } = string.Empty;
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public TipoPrestamo Tipo { get; set; }
}

public enum TipoPrestamo
{
    Prestamo,
    Devolucion
} 