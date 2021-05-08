using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enum tipo
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion 

        #region atributos
        ETipo tipo;
        #endregion 

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo eTipo)
        : base(chasis, marca, color)
        {
            this.tipo = eTipo;
        }
        #endregion 

        #region Propiedades
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion 

        #region Metodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SEDAN");
            sb.AppendFormat("{0}", base.Mostrar());
            sb.AppendLine("");
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion 
    }
}
