using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Usuarios.Queries
{
    public class GetUsuarioByIdQuery
    {
        public record Query(int Id) : IRequest<List<Usuario>>;

        public class Handler : IRequestHandler<Query, List<Usuario>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Usuario>> Handle(Query request, CancellationToken cancellationToken)
            {

                var data = await context.Usuarios
                                        .Where(x => x.Id == request.Id
                                                 && x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                if (data!=null)
                {
                    data[0].Password = UtilStrings.DesEncriptar(data[0].Password);
                }

                return data;
            }
        }
    }
}
