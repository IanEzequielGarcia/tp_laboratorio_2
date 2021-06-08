using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Grafica:Producto,IComponente
    {
        #region enum
        public enum MarcaGrafica { NVIDIA, AMD, Blanca };
        #endregion

        #region atributos
        public string Modelo { get; set; }
        public float Hercio { get; set; }

        public int Cores { get; set; }
        MarcaGrafica marca;
        #endregion

        #region Constructores
        public Grafica()
        {
            this.Modelo = "Sin grafica";
        }
        public Grafica(string modelo,float hercio,int cores, MarcaGrafica marca,
            float precio, GamaProducto gama,TipoProducto tipo):base(precio,gama,tipo)
        {
            this.Modelo = modelo;
            this.Cores = cores;
            this.marca = marca;
            this.Hercio = hercio;
        }
        #endregion

        #region Metodos y sobrecargas
        void IComponente.CalcularVelocidad()
        {
            Random random = new Random();
            this.Hercio = 10 * (float)random.NextDouble();
            throw new NotImplementedException();
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.Mostrar()} MarcaGrafica:{this.marca} Modelo:{this.Modelo} Cores:{this.Cores} Hercios:{this.Hercio} \n");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        #endregion
    }
}
