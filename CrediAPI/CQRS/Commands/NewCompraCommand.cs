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
    public class NewCompraCommand : IRequest<ResponseCmd>
    {
        public int TarjetaID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }

    public class NewCompraCommandCommandHandler : IRequestHandler<NewCompraCommand, ResponseCmd>
    {

        private readonly CrediConsultingDbContext context;
        private readonly IMapper mapper;
        public NewCompraCommandCommandHandler(CrediConsultingDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ResponseCmd> Handle(NewCompraCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var nuevaCompra = mapper.Map<MovimientosDTO>(request);
                var compraRealizada = mapper.Map<Movimientos>(nuevaCompra);
                context.Compras.Add(compraRealizada);
                await context.SaveChangesAsync();
                return new ResponseCmd { Success = true, Message = $"La Compra fue agregada con exito en el sistema!!" };
            }
            catch(Exception ex)
            {
                return new ResponseCmd { Success = false, Message = $"La Compra no pudo agregarse en el sistema!!" };
            }

        }

    }

    public class NewCompraValidator : AbstractValidator<NewCompraCommand>
    {
        public NewCompraValidator()
        {
            RuleFor(x => x.TarjetaID).NotEmpty().NotNull();
            RuleFor(x => x.FechaMovimiento).NotEmpty().NotNull();
            RuleFor(x => x.Descripcion).NotEmpty().NotNull();
            RuleFor(x => x.Monto).NotEmpty().NotNull();
        }
    }
}
