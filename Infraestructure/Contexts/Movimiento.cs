using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public int ProductosId { get; set; }
        public int TiposmovimientosId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? Estado { get; set; }
        public int Creadopor { get; set; }
        public DateTime Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateTime? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateTime? Eliminado { get; set; }

        public virtual Usuario CreadoporNavigation { get; set; } = null!;
        public virtual Producto Productos { get; set; } = null!;
        public virtual Tiposmovimiento Tiposmovimientos { get; set; } = null!;
    }
}
