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
    public class GetPagosByTitularQuery : IRequest<List<PagosTarjetaDTO>>
    {
        public int TitularID { get; set; }
        public GetPagosByTitularQuery(int titularID)
        {
            TitularID = titularID;
        }

        public class GetPagosByTitularQueryHandler : IRequestHandler<GetPagosByTitularQuery, List<PagosTarjetaDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetPagosByTitularQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<List<PagosTarjetaDTO>> Handle(GetPagosByTitularQuery request, CancellationToken cancellationToken)
            {
                var tarjetaUsada = await context.Tarjetas.FirstOrDefaultAsync(x => x.TitularID == request.TitularID);
                var pagosConsultados = await context.Pagos.Where(x => x.TarjetaID == tarjetaUsada.TitularID).ToListAsync();
                if (pagosConsultados == null || pagosConsultados.Count == 0)
                {
                  return new List<PagosTarjetaDTO>();
                }
                return mapper.Map<List<PagosTarjetaDTO>>(pagosConsultados);
            }
        }
    }
}
