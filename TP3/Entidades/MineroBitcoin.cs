using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MineroBitcoin
    {
        #region Atributos y Propiedades
        float precioTotal;
        List<Grafica> minadores;
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
        MineroBitcoin()
        {
            this.minadores = new List<Grafica>();
        }
        public MineroBitcoin(List<Grafica> minadores) : this()
        {
            this.minadores = minadores;
        }
        #endregion

        #region Metodos y sobrecargas
        public void CalcularPrecioTotal()
        {
            foreach(Grafica grafica in this.minadores)
                if((object)grafica!=null)
                    this.precioTotal += grafica.CosteProduccion;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MineroBTC-------------------------");
            foreach (Grafica grafica in this.minadores)
                if ((object)grafica != null)
                    sb.Append($"GPU: {grafica.ToString()}");
            sb.AppendLine($"Coste total de componentes : {this.PrecioTotal}\n");
            return sb.ToString();
        }
        #endregion
    }
}
