using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Computadora
    {
        #region Atributos y propiedades
        public float precioTotal;
        public Procesador procesador;
        public Grafica grafica;
        public float PrecioTotal 
        {
            get {
                    if (this.precioTotal == 0)
                        this.CalcularPrecioTotal();
                    return this.precioTotal;
                }
        }
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
        public void CalcularPrecioTotal()
        {
            this.precioTotal = this.procesador.CosteProduccion + this.grafica.CosteProduccion;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("COMPUTADORA-------------------");
            sb.Append($"CPU: {this.procesador.ToString()}");
            if(!(this.grafica.Modelo=="Sin grafica"))
                sb.Append($"GPU: {this.grafica.ToString()}");
            sb.AppendLine($"Precio total de componentes: {this.PrecioTotal}\n");
            return sb.ToString();
        }
        #endregion

    }
}
