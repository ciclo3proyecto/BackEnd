using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Menu
    {
        public Menu()
        {
            Permisos = new HashSet<Permiso>();
        }

        public int Id { get; set; }
        public string Opcion { get; set; }
        public string Descripcion { get; set; }
        public int PadreId { get; set; }
        public string Ruta { get; set; }
        public string Estado { get; set; }
        public int Creadopor { get; set; }
        public DateTime Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateTime? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateTime? Eliminado { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
