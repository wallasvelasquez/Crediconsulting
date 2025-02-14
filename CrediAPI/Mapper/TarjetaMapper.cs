using AutoMapper;
using CrediAPI.CQRS.Commands;
using CrediAPI.DTO;
using CrediAPI.Models.Entities;

namespace CrediAPI.Mapper
{
    public class TarjetaMapper : Profile
    {
        public TarjetaMapper()
        {
            CreateMap<TarjetasCreditoDTO, TarjetaCredito>().ReverseMap();
            CreateMap<TarjetasCreditoCatalogoDTO, TarjetaCredito>().ReverseMap();
            CreateMap<NewTarjetaCreditoCommand, TarjetasCreditoDTO>();
            CreateMap<EstadoCuentaTarjeta, EstadoCuentaTarjetaCreditoDTO>().ReverseMap();
            CreateMap<Transacciones, TransaccionesDTO>().ReverseMap();
        }
    }
}
