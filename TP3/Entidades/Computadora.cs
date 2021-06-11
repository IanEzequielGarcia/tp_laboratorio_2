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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CPU: {this.procesador.ToString()}");
            if(!(this.grafica.Modelo=="Sin grafica"))
                sb.Append($"GPU: {this.grafica.ToString()}");
            sb.AppendLine($"Precio total de componentes: {this.PrecioTotal}");
            return sb.ToString();
        }
        #endregion

    }
}
