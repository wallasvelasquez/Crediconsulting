using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetCompraByIDQuery : IRequest<MovimientosDTO>
    {
        public int CompraID { get; set; }

        public GetCompraByIDQuery(int compraID)
        {
            CompraID = compraID;
        }

        public class GetCompraByIDQueryHandler : IRequestHandler<GetCompraByIDQuery, MovimientosDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;

            public GetCompraByIDQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<MovimientosDTO> Handle(GetCompraByIDQuery request, CancellationToken cancellationToken)
            {
                var compraConsultada = await context.Compras.FirstOrDefaultAsync(x => x.MovimientoID == request.CompraID);
                if (compraConsultada == null)
                {
                    return null;
                }
                return mapper.Map<MovimientosDTO>(compraConsultada);
            }
        }
    }
}
