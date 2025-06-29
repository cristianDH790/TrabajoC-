using System.ComponentModel.DataAnnotations;

namespace VisualizadorEstructuras.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
} 