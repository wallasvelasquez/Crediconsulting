using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetPagosByTarjetaQuery : IRequest<List<PagosCatalogoDTO>>
    {
        public int TarjetaID { get; set; }
        public int Mes { get; set; }
        public GetPagosByTarjetaQuery(int tarjetaID, int mes)
        {
            TarjetaID = tarjetaID;
            Mes = mes;
        }
        public class GetPagosByTarjetaQueryHandler : IRequestHandler<GetPagosByTarjetaQuery, List<PagosCatalogoDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetPagosByTarjetaQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<List<PagosCatalogoDTO>> Handle(GetPagosByTarjetaQuery request, CancellationToken cancellationToken)
            {
                var comprasTarjeta = await context.Pagos.FromSqlInterpolated($"usp_GetAllPagosPorMes {request.TarjetaID}, {request.Mes}").ToListAsync();
                if (comprasTarjeta == null)
                {
                    return null;
                }
                return mapper.Map<List<PagosCatalogoDTO>>(comprasTarjeta);
            }
        }
    }

}
