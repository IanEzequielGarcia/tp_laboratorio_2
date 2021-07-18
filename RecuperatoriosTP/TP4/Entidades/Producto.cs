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
    [XmlInclude(typeof(Procesador)), XmlInclude(typeof(Grafica))]
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
        public float CosteProduccion { get {return this.costeProduccion; } set { this.costeProduccion = value; } }
        public GamaProducto Gama { get { return this.gama; } }
        public TipoProducto Tipo { get { return this.tipo; } }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        {
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="costeProduccion"></param>
        /// <param name="gama"></param>
        /// <param name="tipo"></param>
        public Producto(float costeProduccion, GamaProducto gama, TipoProducto tipo)
        {
            this.costeProduccion = costeProduccion;
            this.gama = gama;
            this.tipo = tipo;
        }
        #endregion

        #region Metodos y sobrecargas
        /// <summary>
        /// Devuelve los atributos de Producto en string
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"costeProduccion:{this.CosteProduccion} Gama:{this.gama} Tipo:{this.tipo} ");
            return sb.ToString();
        }
        /// <summary>
        /// Chequea que los atributos de dos productos sean iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.Gama == p2.Gama && p1.CosteProduccion == p2.CosteProduccion && p1.Tipo == p2.Tipo);
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// devuelve this.Mostrar() en string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
