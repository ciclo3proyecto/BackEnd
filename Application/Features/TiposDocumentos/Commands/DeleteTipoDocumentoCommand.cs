using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using System.Diagnostics;

namespace InventoryApp.Api.Application.Features.TiposDocumentos.Commands
{
    public class DeleteTipoDocumentoCommand
    {
        public record Command(DeleteTiposDocumentoDto DeleteTiposDocumentoDto) : IRequest<CommandResult<Tiposdocumento>>;

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
                    var register = context.Tiposdocumentos.Find(command.DeleteTiposDocumentoDto.Id);
                    register.Estado = EstadosConstants.Inactivo;
                    register.Eliminado = DateOnly.FromDateTime(DateTime.Now);
                    register.Eliminadopor = command.DeleteTiposDocumentoDto.Eliminadopor;

                    context.Tiposdocumentos.Update(register);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Tiposdocumento>.Ok(register);
                }
                catch (Exception e)
                {
                    return CommandResult<Tiposdocumento>.Fail(e.Message);
                }
            }
        }
    }
}
