using AutoMapper;
using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Application.Features.Productos.Commands;
using InventoryApp.Api.Application.Features.Productos.Queries;
using InventoryApp.Api.Application.Features.Usuarios.Commands;
using InventoryApp.Api.Application.Features.Usuarios.Queries;
using InventoryApp.Api.Infraestructure.Exceptions;
using InventoryApp.Api.Infraestructure.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventoryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductosController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductoDto>>> GetUsuarios()
        {
            GetAllProductosQuery.Query query = new();

            var data = await mediator.Send(query);

            return Ok(data);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(List<ProductoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProductoDto>>> GetUsuario(int Id)
        {
            GetProductoByIdQuery.Query query = new(Id);

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<ProductoDto>>(data));
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> CreateUsuario(CreateProductoDto CreateProductoDto)
        {
            CreateProductoCommand.Command command = new(CreateProductoDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<ProductoDto>(response.Data);

            return Ok(result);

        }


        [HttpPut]
        public async Task<ActionResult<ProductoDto>> UpdateUsuario(UpdateProductoDto UpdateProductoDto)
        {
            UpdateProductoCommand.Command command = new(UpdateProductoDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<ProductoDto>(response.Data);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUsuario(DeleteProductoDto DeleteProductoDto)
        {
            DeleteProductoCommand.Command command = new(DeleteProductoDto);

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
