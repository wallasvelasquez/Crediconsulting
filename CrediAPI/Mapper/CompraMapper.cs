using AutoMapper;
using CrediAPI.CQRS.Commands;
using CrediAPI.DTO;
using CrediAPI.Models.Entities;

namespace CrediAPI.Mapper
{
    public class CompraMapper : Profile
    {
        public CompraMapper()
        {
            CreateMap<MovimientosDTO, Movimientos>().ReverseMap();
            CreateMap<MovimientosCatalogoDTO, Movimientos>().ReverseMap();
            CreateMap<NewCompraCommand, MovimientosDTO>();
        }
    }
}
