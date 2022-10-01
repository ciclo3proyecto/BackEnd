using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Utils;

namespace InventoryApp.Api.Application.Validators.Helpers
{
    public class ValidationUsuariosDB
    {
        private readonly g5FtGnkAVWContext context;

        public ValidationUsuariosDB(g5FtGnkAVWContext context)
        {
            this.context = context;
        }


        public bool ExistUsuario(string login, string password)
        {
            var passwordEncritado = UtilStrings.Encriptar(password);

            var exist = context.Usuarios
                                .Where(x => x.Login.Trim().ToLower() == login.Trim().ToLower()
                                         && x.Password.Trim().ToLower() == passwordEncritado.Trim().ToLower()
                                         && x.Estado == EstadosConstants.Activo
                                      )
                                .FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistIdentificacion(decimal identificacion, int id = 0)
        {

            var exist = context.Usuarios
                                .Where(x => x.Id != id
                                         && x.Identificacion == identificacion
                                         && x.Estado == EstadosConstants.Activo
                                      )
                                .FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistLogin(string login,int id = 0)
        {

            var exist = context.Usuarios
                                .Where(x => x.Id != id
                                         && x.Login.Trim().ToLower() == login.Trim().ToLower()
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
