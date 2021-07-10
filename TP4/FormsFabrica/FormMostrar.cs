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
    public partial class FormMostrar : Form
    {
        public string TextBoxMostrar { set { this.textBoxMostrar.Text = value; } }
        public FormMostrar()
        {
            InitializeComponent();
        }
        public FormMostrar(FabricaDeposito<TiposElectronicos> fabricaDeposito):this()
        {
            try { this.TextBoxMostrar = fabricaDeposito.ToString(); }
            catch (Exception e)
            {
                throw new Excepciones(e);
            }
        }
    }
}
