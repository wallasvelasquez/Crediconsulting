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
    public class GetAllTarjetaByTitularQuery : IRequest<List<TarjetasCreditoDTO>>
    {
        public int TitularID { get; set; }

        public GetAllTarjetaByTitularQuery(int titularID)
        {
            TitularID = titularID;
        }

        public class GetAllTarjetaByTitularQueryHandler : IRequestHandler<GetAllTarjetaByTitularQuery, List<TarjetasCreditoDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetAllTarjetaByTitularQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<List<TarjetasCreditoDTO>> Handle(GetAllTarjetaByTitularQuery request, CancellationToken cancellationToken)
            {
                var tarjetasTitular = await context.Tarjetas.Where(x => x.TitularID == request.TitularID).ToListAsync();
                if (tarjetasTitular == null || tarjetasTitular.Count == 0)
                {
                    return new List<TarjetasCreditoDTO>();
                }
                return mapper.Map<List<TarjetasCreditoDTO>>(tarjetasTitular);
            }
        }
    }
}
