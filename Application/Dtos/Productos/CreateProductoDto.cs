namespace InventoryApp.Api.Application.Dtos.Productos
{
    public class CreateProductoDto
    {
        public int UnidadesId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Existencia { get; set; }
        public int Creadopor { get; set; }
        
    }
}
