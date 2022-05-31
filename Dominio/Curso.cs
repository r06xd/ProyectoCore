using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Curso
    {
        public Guid Id {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime FechaPublicacion {get;set;}
        public Precio PrecioPromocion {get;set;}
        public ICollection<Comentario> Comentarios {get;set;}
        public ICollection<CursoInstructor> Instructores{get;set;}
    }
}