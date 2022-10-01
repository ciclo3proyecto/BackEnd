using AutoMapper;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Features.TiposDocumentos.Commands;
using InventoryApp.Api.Application.Features.TiposDocumentos.Queries;
using InventoryApp.Api.Infraestructure.Contexts;
using InventoryApp.Api.Infraestructure.Exceptions;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventoryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiposDocumentosController : ControllerBase
    {

        private readonly  IMediator mediator;
        private readonly IMapper mapper;

        public TiposDocumentosController( IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<TiposDocumentoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TiposDocumentoDto>>> Get()
        {
            GetAllTiposDocumentosQuery.Query query = new();

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<TiposDocumentoDto>>(data));


        }


        [HttpPost]
        public async Task<ActionResult<TiposDocumentoDto>> Create(CreateTiposDocumentoDto CreateTiposDocumentoDto)
        {
            CreateTipoDocumentoCommand.Command command = new(CreateTiposDocumentoDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<TiposDocumentoDto>(response.Data);

            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<TiposDocumentoDto>> Update(UpdateTiposDocumentoDto UpdateTiposDocumentoDto)
        {
            UpdateTipoDocumentoCommand.Command command = new(UpdateTiposDocumentoDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<TiposDocumentoDto>(response.Data);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteTiposDocumentoDto DeleteTiposDocumentoDto)
        {
            DeleteTipoDocumentoCommand.Command command = new(DeleteTiposDocumentoDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }
            return Ok();
        }
    }
}
