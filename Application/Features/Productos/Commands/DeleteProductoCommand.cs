using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;

namespace InventoryApp.Api.Application.Features.Productos.Commands
{
    public class DeleteProductoCommand
    {
        public record Command(DeleteProductoDto DeleteProductoDto) : IRequest<CommandResult<Producto>>;

        public class Handler : IRequestHandler<Command, CommandResult<Producto>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<CommandResult<Producto>> Handle(Command command, CancellationToken cancellationToken)
            {
                try
                {
                    var register = context.Productos.Find(command.DeleteProductoDto.Id);
                    register.Estado = EstadosConstants.Inactivo;
                    register.Eliminado = DateTime.Now;
                    register.Eliminadopor = command.DeleteProductoDto.Eliminadopor;

                    context.Productos.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Producto>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Producto>.Fail(e.Message);
                }
            }
        }
    }
}
