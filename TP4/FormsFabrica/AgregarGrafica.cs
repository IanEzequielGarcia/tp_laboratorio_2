using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
namespace FormsFabrica
{
    public partial class AgregarGrafica : Form
    {
        private int coresForm;
        public int CoresForm { get { return this.coresForm; } }
        private string modelo;
        public string Modelo { get { return this.modelo; } }
        private float precioForm;
        public float PrecioForm { get { return this.precioForm; } }
        private Grafica.MarcaGrafica marcaGrafica;
        public Grafica.MarcaGrafica MarcaGrafica { get { return this.marcaGrafica; } }

        private Grafica.GamaProducto gamaGrafica;
        public Grafica.GamaProducto GamaGrafica { get { return this.gamaGrafica; } }

        private Grafica.TipoProducto tipoGrafica;
        public Grafica.TipoProducto TipoGrafica{ get { return this.tipoGrafica; } }
        public AgregarGrafica()
        {
            InitializeComponent();
            this.comboBoxMarca.SelectedIndex = 2;
            this.comboGama.SelectedIndex = 0;
            this.comboTipo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            float.TryParse(this.txtPrecio.Text, out this.precioForm);
            int.TryParse(this.txtCores.Text, out this.coresForm);
            this.modelo = txtModelo.Text;
            Enum.TryParse(this.comboBoxMarca.SelectedItem.ToString(), out Grafica.MarcaGrafica marcaGrafica);
            Enum.TryParse(this.comboGama.SelectedItem.ToString(), out Grafica.GamaProducto gamaGrafica);
            Enum.TryParse(this.comboTipo.SelectedItem.ToString(), out Grafica.TipoProducto tipoGrafica);
        }
    }
}
