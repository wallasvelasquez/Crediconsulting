using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetComprasByTitularQuery : IRequest<List<MovimientosDTO>>
    {
        public int TitularID { get; set; }

        public GetComprasByTitularQuery(int titularID)
        {
            TitularID = titularID;
        }

        public class GetCompraByTitularQueryHandler : IRequestHandler<GetComprasByTitularQuery, List<MovimientosDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;

            public GetCompraByTitularQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<List<MovimientosDTO>> Handle(GetComprasByTitularQuery request, CancellationToken cancellationToken)
            {
                var tarjetaUsada = await context.Tarjetas.FirstOrDefaultAsync(x => x.TitularID == request.TitularID);
                var comprasConsultadas = await context.Compras.Where(x => x.TarjetaID == tarjetaUsada.TitularID).ToListAsync();                
                if (comprasConsultadas == null || comprasConsultadas.Count == 0)
                {
                    return new List<MovimientosDTO>();
                }
                return mapper.Map<List<MovimientosDTO>>(comprasConsultadas);
            }
        }
    }
}
