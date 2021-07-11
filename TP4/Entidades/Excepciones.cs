using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Excepciones:Exception
    {
        public Excepciones():base()
        {
        }
        public Excepciones(string mensaje) : base(mensaje)
        {
        }
        public Excepciones(Exception innerException) : base(innerException.Message)
        {
        }
        public Excepciones(string mensaje,Exception innerException) : base(mensaje,innerException)
        {
        }
    }
    public static class ExcepcionYaEnAlmacen
    {
        public static string YaEnAlmacen(this Excepciones excepciones)
        {
            return "Ya se encuentra en el Almacen ";
        }
    }
}
