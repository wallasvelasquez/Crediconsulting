using AutoMapper;
using CrediAPI.CQRS.Commands;
using CrediAPI.DTO;
using CrediAPI.Models.Entities;

namespace CrediAPI.Mapper
{
    public class TitularMapper : Profile
    {
        public TitularMapper()
        {
            CreateMap<TitularesTarjetaDTO, Titular>().ReverseMap();
            CreateMap<TitularesCatalogoDTO, Titular>().ReverseMap();
            CreateMap<NewTitularCommand, TitularesTarjetaDTO>();
        }
    }
}
