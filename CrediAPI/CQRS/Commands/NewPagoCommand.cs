using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using CrediAPI.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Commands
{
   
    public class NewPagoCommand : IRequest<ResponseCmd>
    {
        public int TarjetaID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
   
    public class NewPagoCommandHandler : IRequestHandler<NewPagoCommand, ResponseCmd>
    {

        private readonly CrediConsultingDbContext context;
        private readonly IMapper mapper;
        public NewPagoCommandHandler(CrediConsultingDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ResponseCmd> Handle(NewPagoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var nuevoPago = mapper.Map<PagosTarjetaDTO>(request);
                var pagar = mapper.Map<Pagos>(nuevoPago);
                context.Pagos.Add(pagar);
                await context.SaveChangesAsync();
                return new ResponseCmd { Success = true, Message = $"El pago fue realizado con exito en el sistema!" };
            }
            catch (Exception ex)
            {
                
                return new ResponseCmd { Success = false, Message = $"El pago no pudo realizarse en el sistema!" };
            }
        }
    }

    public class NewPagoValidator : AbstractValidator<NewPagoCommand>
    {
        public NewPagoValidator()
        {
            RuleFor(x => x.TarjetaID).NotEmpty().NotNull();
            RuleFor(x => x.FechaPago).NotEmpty().NotNull();
            RuleFor(x => x.Monto).NotEmpty().NotNull();
            RuleFor(x => x.MetodoPago).NotEmpty().NotNull();
        }
    }
}
