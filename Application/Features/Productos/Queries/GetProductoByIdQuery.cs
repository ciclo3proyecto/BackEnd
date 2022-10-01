using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Productos.Queries
{
    public class GetProductoByIdQuery
    {
        public record Query(int Id) : IRequest<List<Producto>>;

        public class Handler : IRequestHandler<Query, List<Producto>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Producto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var data = await context.Productos
                                        .Where(x => x.Id == request.Id
                                                 && x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
