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
    public class GetTransaccionesTarjetaQuery : IRequest<List<TransaccionesDTO>>
    {
        public int TarjetaID { get; set; }
        public GetTransaccionesTarjetaQuery(int numeroTarjeta)
        {
            TarjetaID = numeroTarjeta;
        }
        public class GetTransaccionesTarjetaQueryHandler : IRequestHandler<GetTransaccionesTarjetaQuery, List<TransaccionesDTO>>
        {
            private readonly CrediConsultingDbContext context;
            private readonly IMapper mapper;
            public GetTransaccionesTarjetaQueryHandler(CrediConsultingDbContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }
            public async Task<List<TransaccionesDTO>> Handle(GetTransaccionesTarjetaQuery request, CancellationToken cancellationToken)
            {
                var transacciones = await context.Set<Transacciones>().FromSqlInterpolated($"usp_HistorialTransaccionesPorTarjeta {request.TarjetaID}").AsNoTracking().ToListAsync();
                if (transacciones == null)
                {
                    return null;
                }
               return mapper.Map<List<TransaccionesDTO>>(transacciones);
            }
        }
    }
}
