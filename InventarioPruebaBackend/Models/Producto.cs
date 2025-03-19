using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
}
