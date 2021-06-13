using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class FabricaDeposito<T> where T : class
    {
        #region Atributos 
        private int _capacidadMaxima;
        private List<TiposElectronicos> _lista;
        #endregion

        #region Propiedades 
        public List<TiposElectronicos> Lista { get {return this._lista; } }
        public int  Capacidad { get {return this._capacidadMaxima; } }
        #endregion

        #region Constructores 
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FabricaDeposito()
        {
            this._lista = new List<TiposElectronicos>();
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="capacidad"></param>
        public FabricaDeposito(int capacidad):this()
        {
            this._capacidadMaxima = capacidad;
        }
        #endregion

        #region Metodos y Sobrecargas
        /// <summary>
        /// Agrega el TipoElectronico a la fabrica
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static public FabricaDeposito<T> operator +(FabricaDeposito<T> d, TiposElectronicos a)
        {
            d.Agregar(a);
            return d;
        }
        /// <summary>
        /// Agrega los los tipos electronicos de una fabrica a la otra
        /// </summary>
        /// <param name="d"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        static public FabricaDeposito<T> operator +(FabricaDeposito<T> d, FabricaDeposito<T> d2)
        {
            foreach(TiposElectronicos electronicos in d.Lista)
            {
                if(!ReferenceEquals(electronicos,null)&& d2 != electronicos)
                {
                    d += electronicos;
                }
            }
            return d;
        }
        /// <summary>
        /// Agrega el tipo electronico a la fabrica this
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Agregar(TiposElectronicos a)
        {
            if (this._capacidadMaxima > this._lista.Count)
            {
                if(this != a)
                {
                    this._lista.Add(a);
                    return true;
                }
                else {
                    Console.WriteLine("Ya se encuentra en el deposito"); }
            }else{
                Console.WriteLine("El Deposito esta lleno");
            }
            return false;
        }
        /// <summary>
        /// devuelve el indice de Tipos electronicos en la fabrica(si se encuentra)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int GetIndice(TiposElectronicos a)
        {
            int retornado = 0;
            if (!ReferenceEquals(a, null))
            {
                foreach (TiposElectronicos Ts in this._lista)
                {
                    if (!ReferenceEquals(Ts, null) && Ts==a)
                        return retornado;
                    retornado++;
                }
            }
            return -1;
        }
        /// <summary>
        /// Borra un Tipo deposito de la Fabrica
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static public FabricaDeposito<T> operator -(FabricaDeposito<T> d, TiposElectronicos a)
        {
            if (d.Remover(a))
            {
                
            }
            else
            {
                Console.WriteLine("no se pudo borrar");
            }
            return d;
        }
        /// <summary>
        /// Remueve el Tipo electronico de la fabrica si se encuentra
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Remover(TiposElectronicos a)
        {
            if (this==a)
            {
                this._lista.RemoveAt(this.GetIndice(a));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Comprueba que el TipoE se encuentre en la fabrica
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="t1"></param>
        /// <returns></returns>
        public static bool operator ==(FabricaDeposito<T> f1, TiposElectronicos t1)
        {
            bool aux = false;
            foreach(TiposElectronicos auxTiposElectronicos in f1._lista)
            {
                if (!ReferenceEquals(auxTiposElectronicos, null) && auxTiposElectronicos == t1)
                    aux = true;
            }
            return aux;
        }
        public static bool operator !=(FabricaDeposito<T> f1, TiposElectronicos t1)
        {
            return !(f1 == t1);
        }
        /// <summary>
        /// Muestra todos los Tipos electronicos almacenados en el deposito
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Deposito-------------------");
            sb.AppendLine($"CantidadMaxima: {this._capacidadMaxima}");
            sb.AppendLine("En el Almacen:");

            foreach (TiposElectronicos Ts in this._lista)
            {
                
                if (!ReferenceEquals(Ts, null))
                {
                    sb.AppendLine($"{Ts.GetType().Name}----------");
                    sb.Append(Ts.ToString());
                }
            }
            sb.AppendLine();
            return sb.ToString();
        }
        #endregion
    }
}

