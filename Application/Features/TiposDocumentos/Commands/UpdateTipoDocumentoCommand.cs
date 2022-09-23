using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using System.Diagnostics;

namespace InventoryApp.Api.Application.Features.TiposDocumentos.Commands
{
    public class UpdateTipoDocumentoCommand
    {
        public record Command(UpdateTiposDocumentoDto UpdateTiposDocumentoDto) : IRequest<CommandResult<Tiposdocumento>>;

        public class Handler : IRequestHandler<Command, CommandResult<Tiposdocumento>>
        {
            private readonly g5FtGnkAVWContext context;

            public Handler(g5FtGnkAVWContext context)
            {
                this.context = context;
            }

            public async Task<CommandResult<Tiposdocumento>> Handle(Command command, CancellationToken cancellationToken)
            {
                try
                {
                    var register = context.Tiposdocumentos.Find(command.UpdateTiposDocumentoDto.Id);

                    register.Descripcion = command.UpdateTiposDocumentoDto.Descripcion;
                    register.Actualizadopor = command.UpdateTiposDocumentoDto.ActualizaPor;
                    register.Actualizado = DateTime.Now;

                    context.Tiposdocumentos.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Tiposdocumento>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Tiposdocumento>.Fail(e.Message + ": " + e.InnerException);
                }
            }
        }
    }
}
