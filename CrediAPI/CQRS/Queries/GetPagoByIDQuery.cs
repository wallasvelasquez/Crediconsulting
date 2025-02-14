using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetPagoByIDQuery : IRequest<PagosTarjetaDTO>
    {
        public int PagoID { get; set; }
        public GetPagoByIDQuery(int pagoID)
        {
            PagoID = pagoID;
        }

        public class GetPagoByIDQueryHandler : IRequestHandler<GetPagoByIDQuery, PagosTarjetaDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetPagoByIDQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<PagosTarjetaDTO> Handle(GetPagoByIDQuery request, CancellationToken cancellationToken)
            {
                var pagoConsultado = await context.Pagos.FirstOrDefaultAsync(x => x.PagoID == request.PagoID);

                if (pagoConsultado == null)
                {
                    return null;
                }
                return mapper.Map<PagosTarjetaDTO>(pagoConsultado);
            }
        }
    }
}
