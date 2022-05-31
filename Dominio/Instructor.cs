using System.Collections.Generic;
using System;
namespace Dominio
{
    public class Instructor
    {
        public Guid Id {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Grado {get;set;}
        public byte[] FotoPerfil {get;set;}
        public ICollection<CursoInstructor> Cursos{get;set;}
    }
}