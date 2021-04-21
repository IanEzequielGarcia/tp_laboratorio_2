using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        static double Operar(Entidades.Numero elN1, Entidades.Numero elN2, string elOperador)
        {
            return Entidades.Calculadora.Operador(elN1, elN2, elOperador);
        }
        /// <summary>
        /// realiza la operacion aritmetica entre los dos numeros a traves del metodo Operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Entidades.Numero numeroUno = new Entidades.Numero(this.txtNumero1.Text);
            Entidades.Numero numeroDos = new Entidades.Numero(this.txtNumero2.Text);
            this.labelResultado.Text = (FormCalculadora.Operar(numeroUno, numeroDos, this.comboBox2.Text)).ToString();
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
        /// "Limpia" Los campos de texto del form
        /// </summary>
        private void Limpiar()
        {
            this.labelResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.comboBox2.Text = "";
        }
        /// <summary>
        /// Cierra el Windows form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// convierte el resultado de la operacion aritmetica a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecABin_Click(object sender, EventArgs e)
        {
            string num = this.labelResultado.Text;
            Entidades.Numero aux = new Entidades.Numero(num);
            if (num== "Valor inválido" || String.IsNullOrWhiteSpace(num))
                this.labelResultado.Text = "Valor inválido";
            else
            this.labelResultado.Text=aux.DecimalBinario(Double.Parse(num));
        }
        /// <summary>
        /// convierte el resultado de la operacion aritmetica de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBinADec_Click(object sender, EventArgs e)
        {
            string num = this.labelResultado.Text;
            Entidades.Numero aux = new Entidades.Numero(num);
            if (String.IsNullOrWhiteSpace(num))
                this.labelResultado.Text = "Valor inválido";
            else
                this.labelResultado.Text = aux.BinarioDecimal(num);
        }
    }
}
