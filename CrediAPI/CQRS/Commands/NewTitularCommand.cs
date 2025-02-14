using AutoMapper;
using CrediAPI.DTO;
using CrediAPI.Models;
using CrediAPI.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrediAPI.CQRS.Commands
{
    public class NewTitularCommand : IRequest<ResponseCmd>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
    }
    public class ResponseCmd
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class NewTitularCommandHandler : IRequestHandler<NewTitularCommand, ResponseCmd>
    {

        private readonly CrediConsultingDbContext context;
        private readonly IMapper mapper;
        public NewTitularCommandHandler(CrediConsultingDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ResponseCmd> Handle(NewTitularCommand request, CancellationToken cancellationToken)
        {
            var nuevoTitular = mapper.Map<TitularesTarjetaDTO>(request);
            var existTitular = await context.Titulares.AnyAsync(x => x.Nombres + " " + x.Apellidos == nuevoTitular.Nombres + " " + nuevoTitular.Apellidos);
            if (existTitular)
            {
                return new ResponseCmd { Success = false, Message = $"El Titular {nuevoTitular.Nombres} {nuevoTitular.Apellidos} ya existe dentro del sistema!"};
            }
            var titularTarjeta = mapper.Map<Titular>(nuevoTitular);
            context.Titulares.Add(titularTarjeta);
            await context.SaveChangesAsync();
            return  new ResponseCmd { Success = true, Message = $"El Titular fue creado con exito en el sistema!" };
        }
    }
    public class NewTitularValidator : AbstractValidator<NewTitularCommand>
    {
        public NewTitularValidator()
        {
            RuleFor(x => x.Nombres).NotEmpty().NotNull();
            RuleFor(x => x.Apellidos).NotEmpty().NotNull();
        }
    }

}
