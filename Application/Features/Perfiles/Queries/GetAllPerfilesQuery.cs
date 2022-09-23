using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Perfiles.Queries
{
    public class GetAllPerfilesQuery
    {
        public record Query() : IRequest<List<Perfile>>;

        public class Handler : IRequestHandler<Query, List<Perfile>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Perfile>> Handle(Query request, CancellationToken cancellationToken)
            {

                List<Perfile> queries = await context.Perfiles
                                        .Where(x => x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                return queries;
            }
        }
    }
}
