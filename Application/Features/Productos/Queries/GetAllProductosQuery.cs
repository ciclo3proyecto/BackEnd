using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Productos.Queries
{
    public class GetAllProductosQuery
    {
        public record Query() : IRequest<List<ProductoDto>>;

        public class Handler : IRequestHandler<Query, List<ProductoDto>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<List<ProductoDto>> Handle(Query Request, CancellationToken cancellationToken)
            {
                var listUsuarios = new List<ProductoDto>();

                var data = await context.Productos
                                    .Include(p => p.Unidades)
                                    .Where(x => x.Estado == EstadosConstants.Activo)
                                    .Select(r => new {
                                        r.Id,
                                        r.Codigo,
                                        r.Nombre,
                                        r.Precio,
                                        r.Existencia,
                                        r.UnidadesId,
                                        r.Unidades.Descripcion
                                    })
                                    .ToListAsync(cancellationToken);

                foreach (var item in data)
                {
                    listUsuarios.Add(new ProductoDto()
                    {
                        Id = item.Id,
                        Codigo = item.Codigo,
                        Nombre = item.Nombre,
                        Existencia = (decimal)item.Existencia,
                        Precio = (decimal)item.Precio,
                        UnidadesId = item.UnidadesId,
                        DescripcionUnidad = item.Descripcion
                    });

                }


                return listUsuarios;
            }
        }
    }
}
