using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;

namespace InventoryApp.Api.Application.Features.Productos.Commands
{
    public class UpdateProductoCommand
    {
        public record Command(UpdateProductoDto UpdateProductoDto) : IRequest<CommandResult<Producto>>;

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
                    var register = context.Productos.Find(command.UpdateProductoDto.Id);

                    register.UnidadesId = command.UpdateProductoDto.UnidadesId;
                    register.Codigo = command.UpdateProductoDto.Codigo;
                    register.Nombre = command.UpdateProductoDto.Nombre;
                    register.Descripcion = command.UpdateProductoDto.Descripcion;
                    register.Precio = command.UpdateProductoDto.Precio;
                    register.Existencia = command.UpdateProductoDto.Existencia;
                    register.Actualizadopor = command.UpdateProductoDto.Actualizadopor;
                    register.Actualizado = DateTime.Now;

                    context.Productos.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Producto>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Producto>.Fail(e.Message + ": " + e.InnerException);
                }
            }
        }
    }
}
