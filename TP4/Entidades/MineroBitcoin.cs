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
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        MineroBitcoin()
        {
            this.minadores = new List<Grafica>();
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="minadores"></param>
        public MineroBitcoin(List<Grafica> minadores) : this()
        {
            this.minadores = minadores;
        }
        #endregion

        #region Metodos y sobrecargas
        /// <summary>
        /// Suma todos los preciosProduccion de las graficas
        /// </summary>
        public override void CalcularPrecioTotal()
        {
            foreach(Grafica grafica in this.minadores)
                if(!ReferenceEquals(grafica,null))
                    this.precioTotal += grafica.CosteProduccion;
        }
        /// <summary>
        /// Devuelve un string con toda la info del minero y sus graficas
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Grafica grafica in this.minadores)
                if (!ReferenceEquals(grafica, null))
                    sb.Append($"GPU: {grafica.ToString()}");
            sb.AppendLine($"Coste total de componentes : {this.PrecioTotal}");
            return sb.ToString();
        }
        #endregion
    }
}
