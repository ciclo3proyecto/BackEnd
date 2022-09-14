using AutoMapper;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Application.Features.Usuarios.Commands;
using InventoryApp.Api.Infraestructure.Exceptions;
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

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Create(LoginUsuarioDto LoginUsuarioDto)
        {
            LoginUsuarioCommand.Command command = new(LoginUsuarioDto);

            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return StatusCode((int)response.Code, new { Message = response.Error });
                throw new AppException(response.Error, (response.Code is not null) ? (int)response.Code : (int)HttpStatusCode.InternalServerError);
            }

            var result = mapper.Map<UsuarioDto>(response.Data);

            return Ok(result);

        }
    }
}
