using System;
using System.Collections.Generic;

namespace InventoryApp.Api.Infraestructure.Contexts
{
    public partial class Permiso
    {
        public int Id { get; set; }
        public int MenusId { get; set; }
        public int PerfilId { get; set; }
        public string? Estado { get; set; }
        public int? Creadopor { get; set; }
        public DateTime? Creado { get; set; }
        public int? Actualizadopor { get; set; }
        public DateTime? Actualizado { get; set; }
        public int? Eliminadopor { get; set; }
        public DateTime? Eliminado { get; set; }

        public virtual Menu Menus { get; set; } = null!;
        public virtual Perfile Perfil { get; set; } = null!;
    }
}
