using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using InventoryApp.Api.Infraestructure.Utils;
using MediatR;

namespace InventoryApp.Api.Application.Features.Usuarios.Commands
{
    public class UpdateUsuarioCommand
    {
        public record Command(UpdateUsuarioDto UpdateUsuarioDto) : IRequest<CommandResult<Usuario>>;

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
                    var register = context.Usuarios.Find(command.UpdateUsuarioDto.Id);


                    register.Identificacion = command.UpdateUsuarioDto.Identificacion;
                    register.Login = command.UpdateUsuarioDto.Login;
                    register.Password = UtilStrings.Encriptar(command.UpdateUsuarioDto.Password);
                    register.PerfilesId = command.UpdateUsuarioDto.PerfilesId;
                    register.TiposdocumentosId = command.UpdateUsuarioDto.TiposdocumentosId;
                    register.Nombres = command.UpdateUsuarioDto.Nombres;
                    register.Primerapellido = command.UpdateUsuarioDto.Primerapellido;
                    register.Segundoapellido = command.UpdateUsuarioDto.Segundoapellido;
                    register.Actualizadopor = command.UpdateUsuarioDto.Actualizapor;
                    register.Actualizado = DateTime.Now;

                    context.Usuarios.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Usuario>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Usuario>.Fail(e.Message + ": " + e.InnerException);
                }
            }
        }
    }
}
