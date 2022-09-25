using AutoMapper;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using InventoryApp.Api.Infraestructure.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Api.Application.Features.Usuarios.Commands
{
    public class LoginUsuarioCommand
    {
        public record Command(LoginUsuarioDto LoginUsuarioDto) : IRequest<CommandResult<UsuarioDto>>;

        public class Handler : IRequestHandler<Command, CommandResult<UsuarioDto>>
        {
            private readonly g5FtGnkAVWContext context;
            private readonly IMapper mapper;

            public Handler(g5FtGnkAVWContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CommandResult<UsuarioDto>> Handle(Command command, CancellationToken cancellationToken)
            {

                try
                {


                    var data = context.Usuarios
                                .Include(p => p.Perfiles)
                                .Where(x => x.Login.Trim().ToLower() == command.LoginUsuarioDto.Login.Trim().ToLower()
                                         && x.Password.Trim() == UtilStrings.Encriptar(command.LoginUsuarioDto.Password.Trim())
                                         && x.Estado == EstadosConstants.Activo)
                                .Select(r => new { r.Id, r.PerfilesId, 
                                                   r.Login,r.Nombres,
                                                   r.Primerapellido, r.Segundoapellido, r.Perfiles.Descripcion
                                })
                                .FirstOrDefault();
                    if (data == null)
                    {
                        return CommandResult<UsuarioDto>.Fail("No se encontró registros asociados");
                    }
                    else
                    {
                        var usuarioDto = new UsuarioDto()
                        {
                            Id = data.Id,
                            Login = data.Login,
                            NombrePerfil = data.Descripcion,
                            Nombres = data.Nombres,
                            PerfilesId = data.PerfilesId,
                            Primerapellido = data.Primerapellido,
                            Segundoapellido = data.Segundoapellido
                        };

                        return CommandResult<UsuarioDto>.Ok(usuarioDto);
                    }

                }
                catch (Exception e)
                {
                    return CommandResult<UsuarioDto>.Fail(e.Message + ": " + e.InnerException);
                }

            }
        }
    }
}
