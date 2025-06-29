using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualizadorEstructuras.Models;

public class Reserva
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int LibroId { get; set; }

    [ForeignKey("LibroId")]
    public Libro Libro { get; set; } = null!;

    [Required]
    public string NombreSolicitante { get; set; } = string.Empty;

    public DateTime FechaSolicitud { get; set; }
    public DateTime FechaExpiracion { get; set; }
    public bool Activa { get; set; }
} 