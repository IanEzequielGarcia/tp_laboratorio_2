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
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        private Calculadora calculadora;
        #region FormClosing Load e Initalize
        /// <summary>
        /// Llama al metodo limpiar cuando se carga la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            calculadora = new Calculadora();
        }
        /// <summary>
        /// Pregunta si esta seguro de salir cuando intenta cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro?", "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                this.Dispose();
            else
                e.Cancel = true;
        }
        public FormCalculadora()
        {
            InitializeComponent();
        }
        #endregion

        #region MetodosFormCalculadora
        double Operar(Numero elN1, Numero elN2, string elOperador)
        {
            char.TryParse(elOperador,out char aux);
            return calculadora.Operador(elN1, elN2, aux);
        }
        /// <summary>
        /// "Limpia" Los campos de texto del form
        /// </summary>
        private void Limpiar()
        {
            this.labelResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.comboBox2.Text = "";
        }
        #endregion

        #region Botones
        /// <summary>
        /// realiza la operacion aritmetica entre los dos numeros a traves del metodo Operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero numeroUno = new Numero(this.txtNumero1.Text);
            Numero numeroDos = new Numero(this.txtNumero2.Text);
            this.labelResultado.Text = (this.Operar(numeroUno, numeroDos, this.comboBox2.Text)).ToString();
        }
        /// <summary>
        /// Llama a la funcion Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Cierra el Windows form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro?", "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                this.Dispose();
        }
        /// <summary>
        /// convierte el resultado de la operacion aritmetica a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecABin_Click(object sender, EventArgs e)
        {
            string num = this.labelResultado.Text;
            Numero aux = new Numero(num);
            if (num == "Valor inválido" || String.IsNullOrWhiteSpace(num))
                this.labelResultado.Text = "Valor inválido";
            else
                this.labelResultado.Text = aux.DecimalBinario(Double.Parse(num));
        }
        /// <summary>
        /// convierte el resultado de la operacion aritmetica de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBinADec_Click(object sender, EventArgs e)
        {
            string num = this.labelResultado.Text;
            Numero aux = new Numero(num);
            if (String.IsNullOrWhiteSpace(num))
                this.labelResultado.Text = "Valor inválido";
            else
                this.labelResultado.Text = aux.BinarioDecimal(num);
        }
        #endregion
    }
}
