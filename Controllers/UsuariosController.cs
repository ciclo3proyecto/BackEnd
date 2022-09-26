using AutoMapper;
using InventoryApp.Api.Application.Dtos.Menus;
using InventoryApp.Api.Application.Dtos.Usuarios;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UsuariosController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }


        [HttpGet("permisos/")]
        [ProducesResponseType(typeof(List<MenuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MenuDto>>> Get(int perfil_id, int padre_id)
        {
            GetPermisosUsuarioQuery.Query query = new(perfil_id, padre_id);

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<MenuDto>>(data));


        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuarios()
        {
            GetAllUsuariosQuery.Query query = new();

            var data = await mediator.Send(query);

            return Ok(data);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(List<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuario(int Id)
        {
            GetUsuarioByIdQuery.Query query = new(Id);

            var data = await mediator.Send(query);

            return Ok(mapper.Map<List<UsuarioDto>>(data));
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CreateUsuario(CreateUsuarioDto CreateUsuarioDto)
        {
            CreateUsuarioCommand.Command command = new(CreateUsuarioDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<UsuarioDto>(response.Data);

            return Ok(result);

        }


        [HttpPost("login/")]
        public async Task<ActionResult<UsuarioDto>> Create(LoginUsuarioDto LoginUsuarioDto)
        {
            LoginUsuarioCommand.Command command = new(LoginUsuarioDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = response.Data;

            return Ok(result);

        }


        [HttpPut]
        public async Task<ActionResult<UsuarioDto>> UpdateUsuario(UpdateUsuarioDto UpdateUsuarioDto)
        {
            UpdateUsuarioCommand.Command command = new(UpdateUsuarioDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<UsuarioDto>(response.Data);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUsuario(DeleteUsuarioDto DeleteUsuarioDto)
        {
            DeleteUsuarioCommand.Command command = new(DeleteUsuarioDto);

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
