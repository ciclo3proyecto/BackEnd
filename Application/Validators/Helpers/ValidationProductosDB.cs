using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Utils;

namespace InventoryApp.Api.Application.Validators.Helpers
{
    public class ValidationProductosDB
    {
        private readonly g5FtGnkAVWContext context;

        public ValidationProductosDB(g5FtGnkAVWContext context)
        {
            this.context = context;
        }

        public bool ExistCodigo(string codigo, int id = 0)
        {

            var exist = context.Productos
                                .Where(x => x.Id != id
                                         && x.Codigo.Trim().ToLower() == codigo.Trim().ToLower()
                                         && x.Estado == EstadosConstants.Activo
                                      )
                                .FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }
    }
}
