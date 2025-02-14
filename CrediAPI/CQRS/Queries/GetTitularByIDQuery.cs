using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Queries
{
    public class GetTitularByIDQuery : IRequest<TitularesTarjetaDTO>
    {
        public int TitularID { get; set; }
        public GetTitularByIDQuery(int titularID)
        {
            TitularID = titularID;
        }

        public class GetTitularByIDQueryHandler : IRequestHandler<GetTitularByIDQuery, TitularesTarjetaDTO>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetTitularByIDQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<TitularesTarjetaDTO> Handle(GetTitularByIDQuery request, CancellationToken cancellationToken)
            {
                var titularConsultado = await context.Titulares.FirstOrDefaultAsync(x => x.TitularID == request.TitularID);
                if (titularConsultado == null)
                {
                    return null;
                }
                return mapper.Map<TitularesTarjetaDTO>(titularConsultado);
            }
        }
    }


}
