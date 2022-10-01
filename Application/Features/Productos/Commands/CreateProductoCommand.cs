using AutoMapper;
using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;

namespace InventoryApp.Api.Application.Features.Productos.Commands
{
    public class CreateProductoCommand
    {

        public record Command(CreateProductoDto CreateProductoDto) : IRequest<CommandResult<Producto>>;

        public class Handler : IRequestHandler<Command, CommandResult<Producto>>
        {
            private readonly g5FtGnkAVWContext context;
            private readonly IMapper mapper;

            public Handler(g5FtGnkAVWContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CommandResult<Producto>> Handle(Command command, CancellationToken cancellationToken)
            {

                try
                {
                    var data = this.mapper.Map<Producto>(command.CreateProductoDto);
                    data.Creado = DateTime.Now;
                    data.Estado = EstadosConstants.Activo;

                    context.Productos.Add(data);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Producto>.Ok(data);
                }
                catch (Exception e)
                {
                    return CommandResult<Producto>.Fail(e.Message + ": " + e.InnerException);
                }

            }
        }

    }
}
