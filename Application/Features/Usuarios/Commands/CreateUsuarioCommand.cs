using AutoMapper;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using InventoryApp.Api.Infraestructure.Utils;
using MediatR;

namespace InventoryApp.Api.Application.Features.Usuarios.Commands
{
    public class CreateUsuarioCommand
    {
        public record Command(CreateUsuarioDto CreateUsuarioDto) : IRequest<CommandResult<Usuario>>;

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


                    var data = this.mapper.Map<Usuario>(command.CreateUsuarioDto);
                    data.Password = UtilStrings.Encriptar(data.Password);
                    data.Creadopor = 1;
                    data.Creado = DateTime.Now;
                    data.Estado = "Activo";

                    context.Usuarios.Add(data);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Usuario>.Ok(data);
                }
                catch (Exception e)
                {
                    return CommandResult<Usuario>.Fail(e.Message + ": " + e.InnerException);
                }

            }
        }

    }
}
