using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Cursos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly IMediator _mediador;
        
        public CursosController(IMediator mediador){
            _mediador = mediador;
        }

        [HttpGet]
        public async Task<ActionResult<List<Curso>>>Get(){
            return await _mediador.Send(new Consulta.ListaCursos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> Detalle(int id){
            return await _mediador.Send(new ConsultaId.CursoUnico{Id=id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta datosCrear){
            return await _mediador.Send(datosCrear);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data){
            data.Id = id;
            return await _mediador.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id){
            return await _mediador.Send(new Eliminar.Ejecuta{Id=id});
        }

    }
}