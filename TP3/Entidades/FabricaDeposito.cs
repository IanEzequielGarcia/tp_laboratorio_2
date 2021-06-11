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
        public FabricaDeposito()
        {
            this._lista = new List<TiposElectronicos>();
        }
        public FabricaDeposito(int capacidad):this()
        {
            this._capacidadMaxima = capacidad;
        }
        #endregion

        #region Metodos y Sobrecargas
        static public FabricaDeposito<T> operator +(FabricaDeposito<T> d, TiposElectronicos a)
        {
            d.Agregar(a);
            return d;

        }
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
        public int GetIndice(TiposElectronicos a)
        {
            int retornado = 0;
            if (((object)a) != null)
            {
                foreach (TiposElectronicos Ts in this._lista)
                {
                    if ((object)Ts!=null&&Ts==a)
                        return retornado;
                    retornado++;
                }
            }
            return -1;
        }
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
        public bool Remover(TiposElectronicos a)
        {
            if (this==a)
            {
                this._lista.RemoveAt(this.GetIndice(a));
                return true;
            }
            return false;
        }
        public static bool operator ==(FabricaDeposito<T> f1, TiposElectronicos t1)
        {
            bool aux = false;
            foreach(TiposElectronicos auxTiposElectronicos in f1._lista)
            {
                if (((object)(auxTiposElectronicos) != null) && auxTiposElectronicos == t1)
                    aux = true;
            }
            return aux;
        }
        public static bool operator !=(FabricaDeposito<T> f1, TiposElectronicos t1)
        {
            return !(f1 == t1);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Deposito-------------------");
            sb.AppendLine($"CantidadMaxima: {this._capacidadMaxima}");
            sb.AppendLine("Listado:");

            foreach (TiposElectronicos Ts in this._lista)
            {
                if ((object)Ts != null)
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

