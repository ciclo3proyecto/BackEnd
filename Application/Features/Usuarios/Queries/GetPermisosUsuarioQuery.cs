using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Usuarios.Queries
{
    public class GetPermisosUsuarioQuery
    {
        public record Query(int PerfilId,int PadreId) : IRequest<List<Menu>>;

        public class Handler : IRequestHandler<Query, List<Menu>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Menu>> Handle(Query request, CancellationToken cancellationToken)
            {

                //Sacamos las opciones que coprcorrespondientes a la opción padre
                var listOpciones = context.Menus
                                    .Where(x => x.PadreId == request.PadreId
                                             && x.Estado == EstadosConstants.Activo)
                                    .Select(x => x.Id);

                //Del listado anterior sacamos las opciones que tiene permiso el perfil
                var listMenus = context.Permisos
                                        .Where(x => x.PerfilId == request.PerfilId
                                                 && listOpciones.Contains(x.MenusId)
                                                 && x.Estado == EstadosConstants.Activo)
                                        .Select(x => x.MenusId);
                
                //traemos la información solicitado
                var data = await context.Menus
                                        .Where(x => listMenus.Contains(x.Id)
                                                 && x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
