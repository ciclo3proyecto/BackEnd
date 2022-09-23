using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Validators.Helpers
{
    public class ValidationExistEntity
    {
        private readonly g5FtGnkAVWContext context;

        public ValidationExistEntity(g5FtGnkAVWContext context)
        {
            this.context = context;
        }

        public bool ExistTipoDocumento(int id)
        {
            var exist = context.Tiposdocumentos
                               .FirstOrDefault(x => x.Id == id
                                                 && x.Estado == EstadosConstants.Activo);
            if (exist != null)
                return true;
            return false;
        }

        public bool ExistPerfil(int id)
        {
            var exist = context.Perfiles
                               .FirstOrDefault(x => x.Id == id
                                                 && x.Estado == EstadosConstants.Activo);
            if (exist != null)
                return true;
            return false;
        }

        public bool ExistUsuario(int id)
        {
            var exist = context.Usuarios
                               .FirstOrDefault(x => x.Id == id
                                                 && x.Estado == EstadosConstants.Activo);
            if (exist != null)
                return true;
            return false;
        }

    }
}
