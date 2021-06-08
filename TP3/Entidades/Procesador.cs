using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Procesador : Producto, IComponente
    {
        #region enum 
        public enum MarcaProcesador { Intel, AMD, Blanca };
        public enum Generacion { Gen3, Gen5, Gen7, Otro };

        #endregion

        #region atributos 
        public string Modelo { get; set; }
        public float Hercio {get; set;}
        public int Cores { get; set; }

        MarcaProcesador marcaProcesador;
        Generacion gen;
        #endregion

        #region Constructores
        public Procesador()
        {
        }
        public Procesador(string modelo,float hercio,int cores,MarcaProcesador MarcaProcesador, Generacion gen,
            float precio,GamaProducto gama, TipoProducto tipo):base(precio,gama,tipo)
        {
            this.Modelo = modelo;
            this.Hercio = hercio;
            this.Cores = cores;
            this.marcaProcesador = MarcaProcesador;
            this.gen = gen;
        }
        #endregion

        #region Metodos y Sobrecargas
        public static bool operator ==(Procesador p1, Procesador p2)
        {
            return (p1.Modelo == p2.Modelo && p1.marcaProcesador == p2.marcaProcesador && p1.gen==p2.gen && ((Producto)p1) == ((Producto)p2) );
        }
        public static bool operator !=(Procesador p1, Procesador p2)
        {
            return !(p1 == p2);
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.Mostrar()} MarcaProcesador:{this.marcaProcesador} Gen:{this.gen} Modelo:{this.Modelo} Cores:{this.Cores} Hercios:{this.Hercio} \n");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        void IComponente.CalcularVelocidad()
        {
            Random random = new Random();
            this.Hercio = 10 * (float)random.NextDouble();
            throw new NotImplementedException();
        }
        #endregion
    }
}
