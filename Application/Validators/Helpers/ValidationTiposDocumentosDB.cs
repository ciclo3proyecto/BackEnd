using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Validators.Helpers
{
    public class ValidationTiposDocumentosDB
    {
        private readonly g5FtGnkAVWContext context;

        public ValidationTiposDocumentosDB(g5FtGnkAVWContext context)
        {
            this.context = context;
        }

        public bool IsUniqueDescripcion(string descripcion, int id = 0)
        {

            var exist = context.Tiposdocumentos
                                .Where(x => (0 == id || x.Id != id)
                                         && x.Estado == EstadosConstants.Activo
                                         && x.Descripcion.ToLower().Trim().Equals(descripcion.ToLower().Trim())
                                         && x.Descripcion != null
                                         && x.Descripcion != "")
                               .FirstOrDefault();
            if (exist == null)
            {
                return true;
            }
            return false;
        }
    }
}
