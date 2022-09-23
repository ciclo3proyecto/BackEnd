using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Usuarios.Queries
{
    public class GetAllUsuariosQuery
    {
        public record Query() : IRequest<List<Usuario>>;

        public class Handler : IRequestHandler<Query, List<Usuario>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Usuario>> Handle(Query request, CancellationToken cancellationToken)
            {

                var listUsuarios = await context.Usuarios
                                    .Where(x => x.Estado == EstadosConstants.Activo)
                                    .ToListAsync(cancellationToken);

                
                return listUsuarios;
            }
        }
    }
}
