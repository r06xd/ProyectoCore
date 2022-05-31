using MediatR;
using System.Collections.Generic;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<Curso>>{}

        public class Manejador : IRequestHandler<ListaCursos, List<Curso>>
        {
            private readonly CursosOnlineContexto _context;

            public Manejador(CursosOnlineContexto contexto){
                _context = contexto;
            }
            public async Task<List<Curso>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var curso = await _context.Curso.ToListAsync();
                return curso;
            }
        }
    }
}