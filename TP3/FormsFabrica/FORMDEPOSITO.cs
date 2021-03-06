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
    public partial class FormFabrica : Form
    {
        FabricaDeposito<TiposElectronicos> miFabrica;
        public FormFabrica()
        {
            miFabrica = new FabricaDeposito<TiposElectronicos>(100);
            InitializeComponent();
        }

        private void btnCrearCompu_Click(object sender, EventArgs e)
        {
            AgregarProcesador formProcesador = new AgregarProcesador();
            AgregarGrafica formGrafica = new AgregarGrafica();
            Procesador procesadorAux=null;
            Grafica graficaAux = null;
            Computadora computadoraAux=null;
            formProcesador.ShowDialog();
            if(formProcesador.DialogResult==DialogResult.OK)
            {
                try 
                {
                    procesadorAux = new Procesador(formProcesador.Modelo, formProcesador.CoresForm,
                        formProcesador.MarcaProcesador, formProcesador.GeneracionProcesador, formProcesador.PrecioForm,
                        formProcesador.GamaProcesador, formProcesador.TipoProcesador);

                }
                catch(Exception b)
                {
                    throw new Excepciones(b);
                }
            }
            else { procesadorAux = new Procesador(); }
            DialogResult respuesta = MessageBox.Show("Instalar grafica?", "Elija", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    formGrafica.ShowDialog();
                    if (formProcesador.DialogResult == DialogResult.OK)
                    {
                        graficaAux = new Grafica(formGrafica.Modelo, formGrafica.CoresForm,
                             formGrafica.MarcaGrafica, formGrafica.PrecioForm,
                             formGrafica.GamaGrafica, formGrafica.TipoGrafica);
                        computadoraAux = new Computadora(procesadorAux, graficaAux);
                    }
                }
                catch (Exception b)
                {
                    throw new Excepciones(b);
                }
            }
            else { computadoraAux = new Computadora(procesadorAux); }

            if (Procesador.Validar(computadoraAux.ElProcesador) &&Grafica.Validar(computadoraAux.Lagrafica))
            {
                this.miFabrica += computadoraAux;
            }
            else
            {
                MessageBox.Show("Reingrese los datos");
            }
            
        }

        private void btnCrearServer_Click(object sender, EventArgs e)
        {
            AgregarProcesador formProcesador = new AgregarProcesador();
            Procesador procesadorAux = null;
            List<Procesador> listaAux = new List<Procesador>();
            Servidor servidorAux = null;
            DialogResult respuesta;
            do
            {
                try
                {
                    formProcesador.ShowDialog();
                    if (formProcesador.DialogResult == DialogResult.OK)
                    {
                        procesadorAux = new Procesador(formProcesador.Modelo, formProcesador.CoresForm,
                            formProcesador.MarcaProcesador, formProcesador.GeneracionProcesador, formProcesador.PrecioForm,
                            formProcesador.GamaProcesador, formProcesador.TipoProcesador);
                        if(Procesador.Validar(procesadorAux))
                        { listaAux.Add(procesadorAux); }
                    }
                    respuesta = MessageBox.Show("Instalar otro procesador??", "Elija", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }
                catch (Exception b)
                {
                    throw new Excepciones(b);
                }
            } while (respuesta == DialogResult.Yes);

            servidorAux = new Servidor(listaAux);
            if(listaAux.Count>0)
            {
                this.miFabrica += servidorAux;
            }
            else
            {
                MessageBox.Show("Reingrese los datos");
            }
            
        }

        private void btnCrearMinero_Click(object sender, EventArgs e)
        {
            AgregarGrafica formGrafica = new AgregarGrafica();
            Grafica graficaAux = null;
            List<Grafica> listaAux = new List<Grafica>();
            MineroBitcoin servidorAux = null;
            DialogResult respuesta;
            do
            {
                try
                {
                    formGrafica.ShowDialog();
                    if (formGrafica.DialogResult == DialogResult.OK)
                    {
                        graficaAux = new Grafica(formGrafica.Modelo, formGrafica.CoresForm,
                            formGrafica.MarcaGrafica, formGrafica.PrecioForm,
                            formGrafica.GamaGrafica, formGrafica.TipoGrafica);
                        if(Grafica.Validar(graficaAux))
                        { listaAux.Add(graficaAux); }
                    }
                    respuesta = MessageBox.Show("Instalar otra grafica??", "Elija", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }
                catch (Exception b)
                {

                    throw new Excepciones(b);
                }
            } while (respuesta == DialogResult.Yes);

            servidorAux = new MineroBitcoin(listaAux);
            if (listaAux.Count > 0)
            {
                this.miFabrica += servidorAux;
            }
            else
            {
                MessageBox.Show("Reingrese los datos");
            }
        }

        private void btnGuardarTxt_Click(object sender, EventArgs e)
        {
            GuardarYSerializar.GuardarTexto("FabricaDeposito.txt", miFabrica);
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            GuardarYSerializar.SerializarXML("FabricaDepositoXML.xml", miFabrica);

        }

        private void btnCargarTexto_Click(object sender, EventArgs e)
        {
            FormMostrar formMostrar = new FormMostrar();
            formMostrar.TextBoxMostrar= GuardarYSerializar.LeerTexto("FabricaDeposito.txt");
            formMostrar.Show();
        }

        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            FormMostrar formMostrar = new FormMostrar(GuardarYSerializar.DeSerializarXML<TiposElectronicos>("FabricaDepositoXML.xml"));
            formMostrar.Show();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            FormMostrar formMostrar = new FormMostrar(miFabrica);
            formMostrar.Show();
        }
    }
}
