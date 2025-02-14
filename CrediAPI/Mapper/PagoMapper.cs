using AutoMapper;
using CrediAPI.CQRS.Commands;
using CrediAPI.DTO;
using CrediAPI.Models.Entities;

namespace CrediAPI.Mapper
{
    public class PagoMapper : Profile
    {
        public PagoMapper()
        {
            CreateMap<PagosTarjetaDTO, Pagos>().ReverseMap();
            CreateMap<PagosCatalogoDTO, Pagos>().ReverseMap();
            CreateMap<NewPagoCommand, PagosTarjetaDTO>();
        }
    }
}
