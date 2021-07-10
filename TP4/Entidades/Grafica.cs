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
        public MarcaGrafica Marca { get { return this.marca; }set { this.marca = value; }}
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Grafica()
        {
            this.Modelo = "Sin grafica";
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="cores"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        /// <param name="gama"></param>
        /// <param name="tipo"></param>
        public Grafica(string modelo,int cores, MarcaGrafica marca,
            float precio, GamaProducto gama,TipoProducto tipo):base(precio,gama,tipo)
        {
            this.Modelo = modelo;
            this.Cores = cores;
            this.marca = marca;
            ((IComponente)this).CalcularVelocidad();
        }
        #endregion

        #region Metodos y sobrecargas
        void IComponente.CalcularVelocidad()
        {
            Random random = new Random();
            this.Hercio = 10 * (float)random.NextDouble();
        }
        /// <summary>
        /// Devuelve un string con todos los atributos de grafica
        /// </summary>
        /// <returns></returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.Mostrar()} MarcaGrafica:{this.marca} Modelo:{this.Modelo} Cores:{this.Cores} Hercios:{this.Hercio} \n");
            return sb.ToString();
        }
        /// <summary>
        /// devuelve el string de la clase protegida Mostrar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// devuelve true si todos los atributos tienen algo asignado, false en caso contrario
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Validar(Grafica p)
        {
            return (p.Modelo == "Sin grafica") || !( (ReferenceEquals(p, null)) 
                   || (string.IsNullOrWhiteSpace(p.Modelo) || ReferenceEquals(p.Marca, null)
                   || ReferenceEquals(p.Tipo, null) || ReferenceEquals(p.Gama, null) || ReferenceEquals(p.Cores, null)) 
                   );
        }
        #endregion
    }
}
