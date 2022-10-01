using AutoMapper;
using InventoryApp.Api.Application.Dtos.Menus;
using InventoryApp.Api.Application.Dtos.Perfiles;
using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Dtos.Unidades;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateTiposDocumentoDto, Tiposdocumento>().ReverseMap();
            CreateMap<Tiposdocumento, TiposDocumentoDto>().ReverseMap();

            CreateMap<CreateUsuarioDto, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioQueryDto>().ReverseMap();

            CreateMap<CreateProductoDto, Producto>().ReverseMap();
            CreateMap<Producto, CreateProductoDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<Unidade, UnidadDto>().ReverseMap();

            CreateMap<Perfile, PerfileDto>().ReverseMap();
        }
    }
}
