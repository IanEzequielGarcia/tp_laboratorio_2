using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public abstract class Producto
    {
        #region enum 
        public enum GamaProducto { Baja, Media, Alta }
        public enum TipoProducto { Comun, Industrial, Gamer }
        #endregion

        #region Atributos
        protected float costeProduccion;
        protected GamaProducto gama;
        protected TipoProducto tipo;
        #endregion

        #region Propiedades
        public float CosteProduccion { get {return this.costeProduccion; } }
        public GamaProducto Gama { get { return this.gama; } }
        public TipoProducto Tipo { get { return this.tipo; } }
        #endregion

        #region constructores
        public Producto()
        {
        }
        public Producto(float costeProduccion, GamaProducto gama, TipoProducto tipo)
        {
            this.costeProduccion = costeProduccion;
            this.gama = gama;
            this.tipo = tipo;
        }
        #endregion

        #region Metodos y sobrecargas
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"costeProduccion:{this.CosteProduccion} Gama:{this.gama} Tipo:{this.tipo} ");
            return sb.ToString();
        }
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.Gama == p2.Gama && p1.CosteProduccion == p2.CosteProduccion && p1.Tipo == p2.Tipo);
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
