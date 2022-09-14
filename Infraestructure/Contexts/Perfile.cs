using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Perfile
    {
        public Perfile()
        {
            Permisos = new HashSet<Permiso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public int? Creadopor { get; set; }
        public DateOnly? Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateOnly? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateOnly? Eliminado { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
