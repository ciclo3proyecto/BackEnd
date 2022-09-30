namespace InventoryApp.Api.Application.Dtos.Productos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int UnidadesId { get; set; }
        public string DescripcionUnidad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Existencia { get; set; }
        
    }
}
