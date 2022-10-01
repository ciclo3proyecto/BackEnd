using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Tiposmovimiento
    {
        public Tiposmovimiento()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Afectacion { get; set; }
        public string? Estado { get; set; }
        public int Creadopor { get; set; }
        public DateTime? Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateTime? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateTime? Eliminado { get; set; }

        public virtual Usuario CreadoporNavigation { get; set; } = null!;
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
