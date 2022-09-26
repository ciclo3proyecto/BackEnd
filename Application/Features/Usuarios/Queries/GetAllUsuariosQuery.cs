using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Usuarios.Queries
{
    public class GetAllUsuariosQuery
    {
        public record Query() : IRequest<List<UsuarioDto>>;

        public class Handler : IRequestHandler<Query, List<UsuarioDto>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<UsuarioDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var listUsuarios = new List<UsuarioDto>();

                var data = await context.Usuarios
                                    .Include(p => p.Perfiles)
                                    .Where(x => x.Estado == EstadosConstants.Activo)
                                    .Select(r => new {
                                        r.Id,
                                        r.PerfilesId,
                                        r.Login,
                                        r.Nombres,
                                        r.Primerapellido,
                                        r.Segundoapellido,
                                        r.Perfiles.Descripcion
                                    })
                                    .ToListAsync(cancellationToken);

                foreach (var item in data)
                {
                    listUsuarios.Add(new UsuarioDto()
                    {
                        Id = item.Id,
                        Login = item.Login,
                        NombrePerfil = item.Descripcion,
                        Nombres = item.Nombres,
                        PerfilesId = item.PerfilesId,
                        Primerapellido = item.Primerapellido,
                        Segundoapellido = item.Segundoapellido 
                    });

                }


                return listUsuarios;
            }
        }
    }
}
