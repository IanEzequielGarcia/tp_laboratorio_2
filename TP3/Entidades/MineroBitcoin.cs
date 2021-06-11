using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MineroBitcoin : TiposElectronicos
    {
        #region Atributos y Propiedades
        List<Grafica> minadores;
        public List<Grafica> Minadores { get { return this.minadores; } }
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
        public override void CalcularPrecioTotal()
        {
            foreach(Grafica grafica in this.minadores)
                if((object)grafica!=null)
                    this.precioTotal += grafica.CosteProduccion;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Grafica grafica in this.minadores)
                if ((object)grafica != null)
                    sb.Append($"GPU: {grafica.ToString()}");
            sb.AppendLine($"Coste total de componentes : {this.PrecioTotal}");
            return sb.ToString();
        }
        #endregion
    }
}
