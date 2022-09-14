using AutoMapper;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using InventoryApp.Api.Infraestructure.Utils;
using MediatR;

namespace InventoryApp.Api.Application.Features.Usuarios.Commands
{
    public class LoginUsuarioCommand
    {
        public record Command(LoginUsuarioDto LoginUsuarioDto) : IRequest<CommandResult<Usuario>>;

        public class Handler : IRequestHandler<Command, CommandResult<Usuario>>
        {
            private readonly g5FtGnkAVWContext context;
            private readonly IMapper mapper;

            public Handler(g5FtGnkAVWContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CommandResult<Usuario>> Handle(Command command, CancellationToken cancellationToken)
            {

                try
                {


                    var data = context.Usuarios
                                .Where(x => x.Login.Trim().ToLower() == command.LoginUsuarioDto.Login.Trim().ToLower()
                                         && x.Password.Trim() == UtilStrings.Encriptar(command.LoginUsuarioDto.Password.Trim())
                                         && x.Estado == EstadosConstants.Activo)
                                .FirstOrDefault();
                    if (data == null)
                    {
                        return CommandResult<Usuario>.Fail("No se encontró registros asociados");
                    }
                    else
                    {
                        return CommandResult<Usuario>.Ok(data);
                    }

                }
                catch (Exception e)
                {
                    return CommandResult<Usuario>.Fail(e.Message + ": " + e.InnerException);
                }

            }
        }
    }
}
