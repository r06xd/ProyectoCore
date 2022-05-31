using System;
using System.Net;

namespace Aplicacion.ManejadorError
{
    public class ManejadorExcepccion : Exception
    {
        public HttpStatusCode Codigo {get;}
        public object Errores {get;}
        public ManejadorExcepccion(HttpStatusCode codigo, object errores = null){
            Codigo = codigo;
            Errores = errores;
        }
    }
}