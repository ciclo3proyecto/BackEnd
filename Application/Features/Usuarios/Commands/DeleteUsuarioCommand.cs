using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;

namespace InventoryApp.Api.Application.Features.Usuarios.Commands
{
    public class DeleteUsuarioCommand
    {
        public record Command(DeleteUsuarioDto DeleteUsuarioDto) : IRequest<CommandResult<Usuario>>;

        public class Handler : IRequestHandler<Command, CommandResult<Usuario>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<CommandResult<Usuario>> Handle(Command command, CancellationToken cancellationToken)
            {
                try
                {
                    var register = context.Usuarios.Find(command.DeleteUsuarioDto.Id);
                    register.Estado = EstadosConstants.Inactivo;
                    register.Eliminado = DateTime.Now;
                    register.Eliminadopor = command.DeleteUsuarioDto.Eliminadopor;

                    context.Usuarios.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Usuario>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Usuario>.Fail(e.Message);
                }
            }
        }
    }
}
