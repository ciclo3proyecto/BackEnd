using AutoMapper;
using InventoryApp.Api.Application.Dtos.Perfiles;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Features.Perfiles.Queries;
using InventoryApp.Api.Application.Features.TiposDocumentos.Queries;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PerfilesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PerfileDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PerfileDto>>> Get()
        {
            GetAllPerfilesQuery.Query query = new();

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<PerfileDto>>(data));


        }
    }
}
