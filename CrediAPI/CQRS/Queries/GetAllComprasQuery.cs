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
    public class GetAllComprasQuery : IRequest<List<MovimientosDTO>>
    {
        public class GetAllComprasQueryHandler : IRequestHandler<GetAllComprasQuery, List<MovimientosDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetAllComprasQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                mapper = _mapper;
                context = _context;
            }
            public async Task<List<MovimientosDTO>> Handle(GetAllComprasQuery request, CancellationToken cancellationToken)
            {
                var comprasList = await context.Compras.AsNoTracking().ToListAsync();
                return mapper.Map<List<MovimientosDTO>>(comprasList);
            }
        }
    }
}
