using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Usuario
    {
        public Usuario()
        {
            Movimientos = new HashSet<Movimiento>();
            Productos = new HashSet<Producto>();
            Tiposmovimientos = new HashSet<Tiposmovimiento>();
        }

        public int Id { get; set; }
        public int PerfilesId { get; set; }
        public int TiposdocumentosId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public decimal? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Primerapellido { get; set; }
        public string? Segundoapellido { get; set; }
        public string? Estado { get; set; }
        public int? Creadopor { get; set; }
        public DateTime? Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateTime? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateTime? Eliminado { get; set; }

        public virtual Perfile Perfiles { get; set; } = null!;
        public virtual Tiposdocumento Tiposdocumentos { get; set; } = null!;
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Tiposmovimiento> Tiposmovimientos { get; set; }
    }
}
