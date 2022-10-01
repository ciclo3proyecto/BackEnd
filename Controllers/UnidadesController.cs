using AutoMapper;
using InventoryApp.Api.Application.Dtos.Perfiles;
using InventoryApp.Api.Application.Dtos.Unidades;
using InventoryApp.Api.Application.Features.Perfiles.Queries;
using InventoryApp.Api.Application.Features.Unidades.Queries;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnidadesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UnidadesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UnidadDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UnidadDto>>> Get()
        {
            GetAllUnidadesQuery.Query query = new();

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<UnidadDto>>(data));


        }
    }
}
