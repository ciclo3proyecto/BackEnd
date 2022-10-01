using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Unidades.Queries
{
    public class GetAllUnidadesQuery
    {
        public record Query() : IRequest<List<Unidade>>;

        public class Handler : IRequestHandler<Query, List<Unidade>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Unidade>> Handle(Query request, CancellationToken cancellationToken)
            {

                List<Unidade> queries = await context.Unidades
                                        .Where(x => x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                return queries;
            }
        }
    }
}
