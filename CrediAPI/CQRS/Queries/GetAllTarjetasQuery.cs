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

    public class GetAllTarjetasQuery : IRequest<List<TarjetasCreditoDTO>>
    {
        public class GetAllTarjetasQueryHandler : IRequestHandler<GetAllTarjetasQuery, List<TarjetasCreditoDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetAllTarjetasQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                mapper = _mapper;
                context = _context;
            }
            public async Task<List<TarjetasCreditoDTO>> Handle(GetAllTarjetasQuery request, CancellationToken cancellationToken)
            {
                var tarjetaList = await context.Tarjetas.AsNoTracking().ToListAsync();
                return mapper.Map<List<TarjetasCreditoDTO>>(tarjetaList);
            }
        }
    }
}
