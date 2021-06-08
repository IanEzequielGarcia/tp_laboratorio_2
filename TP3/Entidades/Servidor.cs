using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servidor
    {
        #region Atributos y Propiedades
        float precioTotal;
        List<Procesador> procesadores;
        int espacioDiscoDuro;
        public float PrecioTotal
        {
            get
            {
                if (this.precioTotal == 0)
                    this.CalcularPrecioTotal();
                return this.precioTotal;
            }
        }
        #endregion

        #region Constructores
        Servidor()
        {
            this.procesadores = new List<Procesador>();
        }
        public Servidor(List<Procesador> procesadores,int espacio) : this()
        {
            this.procesadores = procesadores;
            this.espacioDiscoDuro = espacio;
        }
        #endregion

        #region Metodos y sobrecargas
        public void CalcularPrecioTotal()
        {
            foreach (Procesador Procesador in this.procesadores)
                if ((object)Procesador != null)
                    this.precioTotal += Procesador.CosteProduccion;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Servidor-------------------------");
            sb.AppendLine($"Espacio Disco duro: {this.espacioDiscoDuro}");
            foreach (Procesador Procesador in this.procesadores)
                if ((object)Procesador != null)
                    sb.Append($"CPU: {Procesador.ToString()}");
            sb.AppendLine($"Coste total de componentes : {this.PrecioTotal}\n");
            return sb.ToString();
        }
        #endregion
    }
}
