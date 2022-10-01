using AutoMapper;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;

namespace InventoryApp.Api.Application.Features.TiposDocumentos.Commands
{
    public class CreateTipoDocumentoCommand
    {
        public record Command(CreateTiposDocumentoDto CreateTiposDocumentoDto) : IRequest<CommandResult<Tiposdocumento>>;

        public class Handler : IRequestHandler<Command, CommandResult<Tiposdocumento>>
        {
            private readonly g5FtGnkAVWContext context;
            private readonly IMapper mapper;

            public Handler(g5FtGnkAVWContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<CommandResult<Tiposdocumento>> Handle(Command command, CancellationToken cancellationToken)
            {

                try
                {
                    

                    var data = this.mapper.Map<Tiposdocumento>(command.CreateTiposDocumentoDto);

                    data.Creadopor = 1;
                    data.Creado = DateTime.Now;
                    data.Estado = "Activo";

                    context.Tiposdocumentos.Add(data);
                    await context.SaveChangesAsync(cancellationToken);

                    return CommandResult<Tiposdocumento>.Ok(data);
                }
                catch (Exception e)
                {
                    return CommandResult<Tiposdocumento>.Fail(e.Message + ": " + e.InnerException);
                }

            }
        }
    }
}
