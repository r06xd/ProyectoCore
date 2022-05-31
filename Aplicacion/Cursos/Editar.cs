using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Editar
    {
        public class Ejecuta : IRequest{
            public int Id {get;set;}
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

        public class Manejador : IRequestHandler<Ejecuta>{
            private readonly CursosOnlineContexto _context;
            public Manejador(CursosOnlineContexto context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = await _context.Curso.FindAsync(request.Id);
                if(curso ==null)
                {
                    throw new ManejadorExcepccion(HttpStatusCode.NotFound, new {mensaje = "No se encontro el curso a editar"});
                }
                curso.Titulo=request.Titulo??curso.Titulo;
                curso.Descripcion=request.Descripcion??curso.Descripcion;
                curso.FechaPublicacion=request.FechaPublicacion??curso.FechaPublicacion;
                var valor = await _context.SaveChangesAsync();
                if(valor>0)
                {
                    return Unit.Value;
                }
                throw new ManejadorExcepccion(HttpStatusCode.InternalServerError, new {mensaje = "No se pudo actualizar el Curso=>>"+request.Titulo});
                
            }
        }
    }
}