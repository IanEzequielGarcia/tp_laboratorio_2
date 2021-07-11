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

        #region atributos y Propiedades

        public string Modelo { get; set; }
        public float Hercio {get; set;}
        public int Cores { get; set; }
        private MarcaProcesador marcaProcesador;
        public MarcaProcesador MarcaProcesadores { get { return this.marcaProcesador; } set { this.marcaProcesador = value; } }

        private Generacion gen;
        public Generacion Gen { get { return this.gen; }set {this.gen=value; } }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Procesador()
        {
            this.Modelo = "Sin Procesador";
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="cores"></param>
        /// <param name="MarcaProcesador"></param>
        /// <param name="gen"></param>
        /// <param name="precio"></param>
        /// <param name="gama"></param>
        /// <param name="tipo"></param>
        public Procesador(string modelo,int cores,MarcaProcesador MarcaProcesador, Generacion gen,
            float precio,GamaProducto gama, TipoProducto tipo):base(precio,gama,tipo)
        {
            this.Modelo = modelo;
            this.Cores = cores;
            ((IComponente)this).CalcularVelocidad();
            this.marcaProcesador = MarcaProcesador;
            this.gen = gen;
        }
        #endregion

        #region Metodos y Sobrecargas
        /// <summary>
        /// Comprueba que los atributos de dos procesadores sean iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Procesador p1, Procesador p2)
        {
            return (p1.Modelo == p2.Modelo && p1.marcaProcesador == p2.marcaProcesador && p1.gen==p2.gen && ((Producto)p1) == ((Producto)p2) );
        }
        public static bool operator !=(Procesador p1, Procesador p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Devuelve los atributos de Procesador en string
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.Mostrar()} MarcaProcesador:{this.marcaProcesador} Gen:{this.gen} Modelo:{this.Modelo} Cores:{this.Cores} Hercios:{this.Hercio} \n");
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve el string de mostrar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        void IComponente.CalcularVelocidad()
        {
            Random random = new Random();
            this.Hercio = 10 * (float)random.NextDouble();
        }
        /// <summary>
        /// Valida los atributos de Procesador
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Validar(Procesador p)
        {
            return !( ReferenceEquals(p,null) || p.Modelo=="Sin Procesador" || string.IsNullOrWhiteSpace(p.Modelo) || ReferenceEquals(p.Hercio, null)|| p.Hercio==0
                   || ReferenceEquals(p.MarcaProcesadores, null)|| ReferenceEquals(p.Tipo, null) || ReferenceEquals(p.Gama, null) 
                   || ReferenceEquals(p.Gen, null) || ReferenceEquals(p.Cores, null) || p.Cores==0
                   );
        }
        #endregion
    }
}
