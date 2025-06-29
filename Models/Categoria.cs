using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisualizadorEstructuras.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    
    // Propiedades para la jerarquía
    public int? CategoriaPadreId { get; set; }
    public virtual Categoria? CategoriaPadre { get; set; }
    public virtual ICollection<Categoria> Subcategorias { get; set; } = new List<Categoria>();
    
    // Propiedad de navegación para libros
    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    
    // Propiedades calculadas
    public bool EsCategoriaRaiz => CategoriaPadreId == null;
    public int Nivel => CategoriaPadre?.Nivel + 1 ?? 0;
    public string NombreCompleto => CategoriaPadre != null ? $"{CategoriaPadre.Nombre} > {Nombre}" : Nombre;
} 