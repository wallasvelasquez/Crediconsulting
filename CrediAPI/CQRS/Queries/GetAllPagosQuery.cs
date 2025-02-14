using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using CrediAPI.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetAllPagosQuery : IRequest<List<PagosTarjetaDTO>>
    {
        public class GetAllPagosQueryHandler : IRequestHandler<GetAllPagosQuery, List<PagosTarjetaDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetAllPagosQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                mapper = _mapper;
                context = _context;
            }
            public async Task<List<PagosTarjetaDTO>> Handle(GetAllPagosQuery request, CancellationToken cancellationToken)
            {
                var pagosList = await context.Pagos.AsNoTracking().ToListAsync();
                return mapper.Map<List<PagosTarjetaDTO>>(pagosList);
            }
        }
    }
}
