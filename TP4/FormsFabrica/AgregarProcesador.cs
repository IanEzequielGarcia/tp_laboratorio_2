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
    public partial class AgregarProcesador : Form
    {
        private int coresForm;
        public int CoresForm { get { return this.coresForm; } }
        private string modelo;
        public string Modelo { get { return this.modelo; } }
        private float precioForm;
        public float PrecioForm { get { return this.precioForm; } }
        private Procesador.MarcaProcesador marcaProcesador;
        public Procesador.MarcaProcesador MarcaProcesador { get { return this.marcaProcesador; } }
        private Procesador.Generacion generacionProcesador;
        public Procesador.Generacion GeneracionProcesador { get { return this.generacionProcesador; } }

        private Procesador.GamaProducto gamaProcesador;
        public Procesador.GamaProducto GamaProcesador { get { return this.gamaProcesador; } }

        private Procesador.TipoProducto tipoProcesador;
        public Procesador.TipoProducto TipoProcesador{ get { return this.tipoProcesador; }
}
public AgregarProcesador()
        {
            InitializeComponent();
            this.comboBoxGeneracion.SelectedIndex = 3;
            this.comboBoxMarca.SelectedIndex = 2;
            this.comboGama.SelectedIndex = 0;
            this.comboTipo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                float.TryParse(this.txtPrecio.Text, out this.precioForm);
                int.TryParse(this.txtCores.Text, out this.coresForm);
                this.modelo = txtModelo.Text;
                Enum.TryParse(this.comboBoxMarca.SelectedItem.ToString(), out Procesador.MarcaProcesador marcaProcesador);
                Enum.TryParse(this.comboBoxGeneracion.SelectedItem.ToString(), out Procesador.Generacion generacionProcesador);
                Enum.TryParse(this.comboGama.SelectedItem.ToString(), out Procesador.GamaProducto gamaProcesador);
                Enum.TryParse(this.comboTipo.SelectedItem.ToString(), out Procesador.TipoProducto tipoProcesador);
            }
            catch (Exception b)
            {
                throw new Excepciones(b.Message);
            }
        }
    }
}
