using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest {   
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime? FechaPublicacion {get;set;}
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x=>x.Titulo).NotNull();
                RuleFor(x=>x.Descripcion).NotEmpty();
                RuleFor(x=>x.FechaPublicacion).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CursosOnlineContexto _context;
            public Manejador(CursosOnlineContexto context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = new Curso{
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion.Value
                };

                _context.Curso.Add(curso);

               var valor = await _context.SaveChangesAsync();
                if(valor>0)
                {
                    return Unit.Value;
                }
                throw new ManejadorExcepccion(HttpStatusCode.InternalServerError, new {mensaje = "No se guarda el valor"});
                
            }
        }
    }
}