using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.TiposDocumentos.Queries
{
    public class GetAllTiposDocumentosQuery
    {
        public record Query() : IRequest<List<Tiposdocumento>>;

        public class Handler : IRequestHandler<Query, List<Tiposdocumento>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<Tiposdocumento>> Handle(Query request, CancellationToken cancellationToken)
            {

                List<Tiposdocumento> queries = await context.Tiposdocumentos
                                        .Where(x => x.Estado == EstadosConstants.Activo)
                                        .ToListAsync(cancellationToken);

                return queries;
            }
        }
    }
}
