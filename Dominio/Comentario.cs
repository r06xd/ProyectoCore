using System;
namespace Dominio
{
    public class Comentario
    {
        public Guid Id {get;set;}
        public string Alumno {get;set;}
        public int Puntaje {get;set;}
        public string ComentarioTexto {get;set;}
        public Guid CursoId {get;set;}
        public Curso Curso {get;set;}
    }
}