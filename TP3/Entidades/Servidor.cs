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
        /// <summary>
        /// Constructor por defecto de servidor
        /// </summary>
        Servidor()
        {
            Random random = new Random();
            this.procesadores = new List<Procesador>();
            this.espacioDiscoDuro = random.Next(1, 1000);
        }
        /// <summary>
        /// Constructor parametrizado de servidor
        /// </summary>
        /// <param name="procesadores"></param>
        public Servidor(List<Procesador> procesadores) : this()
        {
            this.procesadores = procesadores;
        }
        #endregion

        #region Metodos y sobrecargas
        /// <summary>
        /// Suma todos los costes de produccion de los procesadores
        /// </summary>
        public override void CalcularPrecioTotal()
        {
            foreach (Procesador Procesador in this.procesadores)
                if (!ReferenceEquals(Procesador,null))
                    this.precioTotal += Procesador.CosteProduccion;
        }
        /// <summary>
        /// Devuelve un string con todos los atributos de los procesadores
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Espacio Disco duro: {this.espacioDiscoDuro}");
            foreach (Procesador Procesador in this.procesadores)
                if (!ReferenceEquals(Procesador, null))
                    sb.Append($"CPU: {Procesador.ToString()}");
            sb.AppendLine($"Coste total de componentes : {this.PrecioTotal}\n");
            return sb.ToString();
        }
        #endregion
    }
}
