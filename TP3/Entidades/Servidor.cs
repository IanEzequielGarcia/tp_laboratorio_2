using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servidor : TiposElectronicos
    {
        #region Atributos y Propiedades
        private List<Procesador> procesadores;
        private int espacioDiscoDuro;
        public List<Procesador> Procesadores { get { return this.procesadores; }}
        public int EspacioDiscoDuro { get { return this.espacioDiscoDuro; }set { this.espacioDiscoDuro = value; } }

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
        public override void CalcularPrecioTotal()
        {
            foreach (Procesador Procesador in this.procesadores)
                if ((object)Procesador != null)
                    this.precioTotal += Procesador.CosteProduccion;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
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
