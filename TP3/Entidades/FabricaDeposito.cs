using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FabricaDeposito<T> where T : class
    {
        #region Atributos 
        private int _capacidadMaxima;
        private List<T> _lista;
        #endregion

        #region Propiedades 
        public List<T> Lista { get {return this._lista; } }
        public int  Capacidad { get {return this._capacidadMaxima; } }
        #endregion

        #region Constructores 
        public FabricaDeposito()
        {
            this._lista = new List<T>();
        }
        public FabricaDeposito(int capacidad):this()
        {
            this._capacidadMaxima = capacidad;
        }
        #endregion

        #region Metodos y Sobrecargas
        static public bool operator +(FabricaDeposito<T> d, T a)
        {
            if (d.Agregar(a))
            {
                return true;
            }
            else
            {
                Console.WriteLine("El Deposito esta lleno");
                return false;
            }
        }
        public bool Agregar(T a)
        {
            if (this._capacidadMaxima > this._lista.Count && this!=a)
            {
                this._lista.Add(a);
                return true;
            }
            return false;
        }
        private int GetIndice(T a)
        {
            int retornado = 0;
            if (((object)a) != null)
            {
                foreach (T Ts in this._lista)
                {
                    if (Ts==a)
                        return retornado;
                    retornado++;
                }
            }
            return -1;
        }
        static public bool operator -(FabricaDeposito<T> d, T a)
        {
            if (d.Remover(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Remover(T a)
        {
            if (this==a && this.GetIndice(a)>=0)
            {
                this._lista.RemoveAt(this.GetIndice(a));
                return true;
            }
            return false;
        }
        public static bool operator ==(FabricaDeposito<T> f1, T t1)
        {
            bool aux = false;
            foreach(T auxProducto in f1._lista)
            {
                if (((object)(auxProducto) != null) && auxProducto == t1)
                    aux = true;
            }
            return aux;
        }
        public static bool operator !=(FabricaDeposito<T> f1, T t1)
        {
            return !(f1 == t1);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CantidadMaxima: {this._capacidadMaxima}");
            sb.AppendLine("Listado:");

            foreach (T Ts in this._lista)
            {
                if ((object)Ts != null)
                {
                    sb.AppendLine(Ts.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}

