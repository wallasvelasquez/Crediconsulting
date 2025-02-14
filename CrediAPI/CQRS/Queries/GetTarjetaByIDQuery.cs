using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetTarjetaByIDQuery : IRequest<TarjetasCreditoDTO>
    {
        public string NumeroTarjeta { get; set; }
        public GetTarjetaByIDQuery(string numeroTarjeta)
        {
            NumeroTarjeta = numeroTarjeta;
        }

        public class GetTarjetaByIDQueryHandler : IRequestHandler<GetTarjetaByIDQuery, TarjetasCreditoDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetTarjetaByIDQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<TarjetasCreditoDTO> Handle(GetTarjetaByIDQuery request, CancellationToken cancellationToken)
            {
                var tarjetaConsultada = await context.Tarjetas.FirstOrDefaultAsync(x => x.NumeroTarjeta == request.NumeroTarjeta);
                if (tarjetaConsultada == null)
                {
                    return null;
                }
                return mapper.Map<TarjetasCreditoDTO>(tarjetaConsultada);
            }
        }
    }

}
