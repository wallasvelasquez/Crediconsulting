using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using CrediAPI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetEstadoCuentaByTarjetaCreditoQuery : IRequest<EstadoCuentaTarjetaCreditoDTO>
    {
        public int TarjetaID { get; set; }
        public int Mes { get; set; }

        public GetEstadoCuentaByTarjetaCreditoQuery(int tarjetaID, int mes)
        {
            TarjetaID = tarjetaID;
            Mes = mes;
        }
        public class GetEstadoCuentaByTarjetaCreditoQueryHandler : IRequestHandler<GetEstadoCuentaByTarjetaCreditoQuery, EstadoCuentaTarjetaCreditoDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetEstadoCuentaByTarjetaCreditoQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public Task<EstadoCuentaTarjetaCreditoDTO> Handle(GetEstadoCuentaByTarjetaCreditoQuery request, CancellationToken cancellationToken)
            {
                var estadoCuenta = context.Set<EstadoCuentaTarjeta>().FromSqlInterpolated($"usp_GetEstadosDeCuentaPorTarjeta {request.TarjetaID}, {request.Mes}").AsEnumerable().FirstOrDefault();
                if (estadoCuenta == null)
                {
                    return null;
                }
                return Task.FromResult(mapper.Map<EstadoCuentaTarjetaCreditoDTO>(estadoCuenta));
            }
        }
    }
}
