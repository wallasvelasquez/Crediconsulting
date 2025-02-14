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
    public class NewTarjetaCreditoCommand : IRequest<ResponseCmd>
    {
        public int TitularID { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string CVV { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal PorcentajeInteresConfigurable { get; set; }
        public decimal PorcentajeConfigurableSaldoMinimo { get; set; }
    }
   
    public class NewTarjetaCreditoCommandHandler : IRequestHandler<NewTarjetaCreditoCommand, ResponseCmd>
    {

        private readonly CrediConsultingDbContext context;
        private readonly IMapper mapper;
        public NewTarjetaCreditoCommandHandler(CrediConsultingDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ResponseCmd> Handle(NewTarjetaCreditoCommand request, CancellationToken cancellationToken)
        {
            var nuevaTarjeta = mapper.Map<TarjetasCreditoDTO>(request);
            var existTarjeta = await context.Tarjetas.AnyAsync(x => x.NumeroTarjeta == nuevaTarjeta.NumeroTarjeta);
            if (existTarjeta)
            {
                return new ResponseCmd { Success = false, Message = $"La tarjeta con No. {nuevaTarjeta.NumeroTarjeta} ya existe dentro del sistema!" };
            }
            var tarjetaCredito = mapper.Map<TarjetaCredito>(nuevaTarjeta);
            context.Tarjetas.Add(tarjetaCredito);
            await context.SaveChangesAsync();
            return new ResponseCmd { Success = true, Message = $"La tarjeta fue creada con exito en el sistema!" };
        }
        
    }

    public class NewTarjetaCreditoValidator : AbstractValidator<NewTarjetaCreditoCommand>
    {
        public NewTarjetaCreditoValidator()
        {
            RuleFor(x => x.TitularID).NotEmpty().NotNull();
            RuleFor(x => x.NumeroTarjeta).NotEmpty().NotNull();
            RuleFor(x => x.FechaExpiracion).NotEmpty().NotNull();
            RuleFor(x => x.CVV).NotEmpty().NotNull();
            RuleFor(x => x.LimiteCredito).NotEmpty().NotNull();
            RuleFor(x => x.PorcentajeConfigurableSaldoMinimo).NotEmpty().NotNull();
            RuleFor(x => x.PorcentajeInteresConfigurable).NotEmpty().NotNull();
        }
    }
}
