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
    public class GetComprasByTarjetaQuery : IRequest<List<MovimientosCatalogoDTO>>
    {
        public int TarjetaID { get; set; }
        public int Mes { get; set; }
        public GetComprasByTarjetaQuery(int tarjetaID, int mes)
        {
            TarjetaID = tarjetaID;
            Mes = mes;
        }
        public class GetComprasByTarjetaQueryHandler : IRequestHandler<GetComprasByTarjetaQuery, List<MovimientosCatalogoDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetComprasByTarjetaQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<List<MovimientosCatalogoDTO>> Handle(GetComprasByTarjetaQuery request, CancellationToken cancellationToken)
            {
                var comprasTarjeta = await context.Compras.FromSqlInterpolated($"usp_GetAllComprasPorMes {request.TarjetaID}, {request.Mes}").ToListAsync();
                if (comprasTarjeta == null)
                {
                    return null;
                }
                return mapper.Map<List<MovimientosCatalogoDTO>>(comprasTarjeta);
            }
        }
    }
}
