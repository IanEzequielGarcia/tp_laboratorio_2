using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Computadora:TiposElectronicos
    {
        #region Atributos
        private Procesador procesador;
        private Grafica grafica;
        public Procesador ElProcesador { get {return this.procesador; }set { this.procesador = value; } }
        public Grafica Lagrafica { get { return this.grafica; } set { this.grafica = value; } }
        #endregion

        #region Constructores
        Computadora()
        {
            this.procesador = new Procesador();
            this.grafica = new Grafica();
        }
        public Computadora(Procesador procesador):this()
        {
            this.procesador = procesador;
        }
        public Computadora(Procesador procesador,Grafica grafica) : this(procesador)
        {
            this.grafica = grafica;
        }
        #endregion

        #region Metodos y sobrecargas
        public override void CalcularPrecioTotal()
        {
            this.precioTotal = this.procesador.CosteProduccion + this.grafica.CosteProduccion;
        }
        public static bool operator ==(Computadora c1, Computadora c2)
        {
            bool aux = false;
                if (!ReferenceEquals(c1, null)&& !ReferenceEquals(c2, null))
                {
                    aux = (c1.ElProcesador == c2.ElProcesador && c1.Lagrafica==c2.Lagrafica);
                }
            return aux;
        }
        public static bool operator !=(Computadora c1, Computadora c2)
        {
            return !(c1 == c2);
        }
        public override string ToString()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"CPU: {this.procesador.ToString()}");
                if (!(this.grafica.Modelo == "Sin grafica"))
                    sb.Append($"GPU: {this.grafica.ToString()}");
                sb.AppendLine($"Precio total de componentes: {this.PrecioTotal}");
                return sb.ToString();
            }
            catch (Exception b)
            {
                throw new Excepciones(b.Message);
            }
        }
        #endregion
    }
    #region Metodo de Extension
    public static class ComputadoraExtendida
    {
        /// <summary>
        /// Chequea que tenga 3 cores o mas y que tenga 4 hercios o mas
        /// </summary>
        /// <param name="computadora"></param>
        /// <returns> true ó false </returns>
        public static bool EsVeloz(this Computadora computadora)
        {
            bool retornado = false;
            if(Procesador.Validar(computadora.ElProcesador) && Grafica.Validar(computadora.Lagrafica))
            {
                if (computadora.ElProcesador.Cores >= 3 && computadora.ElProcesador.Hercio >= 4)
                    retornado = true;
            }
            return retornado;
        }
    }
    #endregion
}
