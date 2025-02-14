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
    public class GetAllTitularesQuery : IRequest<List<TitularesTarjetaDTO>>
    {
        public class GetAllTitularesQueryHandler : IRequestHandler<GetAllTitularesQuery, List<TitularesTarjetaDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetAllTitularesQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                mapper = _mapper;
                context = _context;
            }
            public async Task<List<TitularesTarjetaDTO>> Handle(GetAllTitularesQuery request, CancellationToken cancellationToken)
            {
                var titularList = await context.Titulares.AsNoTracking().ToListAsync();

                return mapper.Map<List<TitularesTarjetaDTO>>(titularList);
            }
        }
    }
}
