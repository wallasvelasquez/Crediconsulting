using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetTarjetaByTitularQuery : IRequest<TarjetasCreditoDTO>
    {
        public int TitularID { get; set; }
        public GetTarjetaByTitularQuery(int titularID)
        {
            TitularID = titularID;
        }

        public class GetTarjetaByTitularQueryHandler : IRequestHandler<GetTarjetaByTitularQuery, TarjetasCreditoDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetTarjetaByTitularQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<TarjetasCreditoDTO> Handle(GetTarjetaByTitularQuery request, CancellationToken cancellationToken)
            {
                var tarjetaConsultada = await context.Tarjetas.FirstOrDefaultAsync(x => x.TitularID == request.TitularID);
                if (tarjetaConsultada == null)
                {
                    return null;
                }
                return mapper.Map<TarjetasCreditoDTO>(tarjetaConsultada);                
            }
        }
    }
}
