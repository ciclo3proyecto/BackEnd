using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Producto
    {
        public Producto()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int Id { get; set; }
        public int UnidadesId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Existencia { get; set; }
        public string? Estado { get; set; }
        public int Creadopor { get; set; }
        public DateOnly? Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateOnly? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateOnly? Eliminado { get; set; }

        public virtual Usuario CreadoporNavigation { get; set; } = null!;
        public virtual Unidade Unidades { get; set; } = null!;
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
