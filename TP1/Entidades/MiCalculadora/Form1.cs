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

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Entidades.Numero numeroUno = new Entidades.Numero(this.txtNumero1.Text);
            Entidades.Numero numeroDos = new Entidades.Numero(this.txtNumero2.Text);
            this.labelResultado.Text = (FormCalculadora.Operar(numeroUno, numeroDos, this.comboBox2.Text)).ToString();
        }
    }
}
