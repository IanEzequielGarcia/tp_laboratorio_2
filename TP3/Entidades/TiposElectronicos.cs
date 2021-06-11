using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Computadora)), XmlInclude(typeof(MineroBitcoin)), XmlInclude(typeof(Servidor))]
    public abstract class TiposElectronicos
    {
        #region atributos 
        protected float precioTotal;
        #endregion 

        #region metodos 
        abstract public void CalcularPrecioTotal();
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
    }
}
