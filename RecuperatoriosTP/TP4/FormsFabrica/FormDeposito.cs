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
using System.Data.SqlClient;
using System.Threading;
namespace FormsFabrica
{
    public partial class FormFabrica : Form
    {
        #region atributos y constructor
        FabricaDeposito<TiposElectronicos> miFabrica;
        SQLAlmacen sqlAlmacen;

        /// <summary>
        /// Crea una FabricaDeposito con espacio para 100, y configura el DataTable y el dataGridView
        /// </summary>
        public FormFabrica()
        {
            miFabrica = new FabricaDeposito<TiposElectronicos>(100);
            sqlAlmacen = new SQLAlmacen();
            InitializeComponent();

            this.dataGridViewAlmacen.MultiSelect = false;
            this.dataGridViewAlmacen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlmacen.AllowUserToAddRows = false;

            this.dataGridViewProcesador.MultiSelect = false;
            this.dataGridViewProcesador.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProcesador.AllowUserToAddRows = false;

            this.dataGridViewGrafica.MultiSelect = false;
            this.dataGridViewGrafica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGrafica.AllowUserToAddRows = false;
        }
        #endregion

        #region Crear computadora,servidor,minero
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
                    while(!Procesador.Validar(procesadorAux))
                    {
                        MessageBox.Show("Reingrese los datos");
                        formProcesador.ShowDialog();
                        procesadorAux = new Procesador(formProcesador.Modelo, formProcesador.CoresForm,
                        formProcesador.MarcaProcesador, formProcesador.GeneracionProcesador, formProcesador.PrecioForm,
                        formProcesador.GamaProcesador, formProcesador.TipoProcesador);
                    }
                }
                catch(Exception b)
                {
                    MessageBox.Show(b.Message);
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
                    }
                    while(!Grafica.Validar(graficaAux))
                    {
                        MessageBox.Show("Reingrese los datos");
                        formGrafica.ShowDialog();
                        graficaAux = new Grafica(formGrafica.Modelo, formGrafica.CoresForm,
                             formGrafica.MarcaGrafica, formGrafica.PrecioForm,
                             formGrafica.GamaGrafica, formGrafica.TipoGrafica);
                    }
                    computadoraAux = new Computadora(procesadorAux, graficaAux);
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
            else { computadoraAux = new Computadora(procesadorAux); }

            try
            {
                if(computadoraAux.ElProcesador.Modelo != "Sin Procesador")
                {
                    sqlAlmacen.CargarComputadoraADataTable(computadoraAux);
                    ActualizarGrillas();
                }
                else
                {
                    MessageBox.Show("Nada que agregar...");
                }

            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void btnCrearServer_Click(object sender, EventArgs e)
        {
            AgregarProcesador formProcesador = new AgregarProcesador();
            Procesador procesadorAux = null;
            List<Procesador> listaAux = new List<Procesador>();
            Servidor servidorAux = null;
            DialogResult respuesta=DialogResult.Yes;
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
                        while (!Procesador.Validar(procesadorAux))
                        {
                            MessageBox.Show("Reingrese los datos");
                            formProcesador.ShowDialog();
                            procesadorAux = new Procesador(formProcesador.Modelo, formProcesador.CoresForm,
                            formProcesador.MarcaProcesador, formProcesador.GeneracionProcesador, formProcesador.PrecioForm,
                            formProcesador.GamaProcesador, formProcesador.TipoProcesador);
                        }
                        listaAux.Add(procesadorAux);
                    }
                    respuesta = MessageBox.Show("Instalar otro procesador??", "Elija", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            } while (respuesta == DialogResult.Yes);

            servidorAux = new Servidor(listaAux);
            if(listaAux.Count>0)
            {
                try
                {
                    sqlAlmacen.CargarServidorADataTable(servidorAux);
                    ActualizarGrillas();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
            else
            {
                MessageBox.Show("Nada que agregar...");
            }
        }
        private void btnCrearMinero_Click(object sender, EventArgs e)
        {
            AgregarGrafica formGrafica = new AgregarGrafica();
            Grafica graficaAux = null;
            List<Grafica> listaAux = new List<Grafica>();
            MineroBitcoin servidorAux = null;
            DialogResult respuesta = DialogResult.Yes;
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
                        while(!Grafica.Validar(graficaAux))
                        {
                            MessageBox.Show("Reingrese los datos");
                            formGrafica.ShowDialog();
                            graficaAux = new Grafica(formGrafica.Modelo, formGrafica.CoresForm,
                                 formGrafica.MarcaGrafica, formGrafica.PrecioForm,
                                 formGrafica.GamaGrafica, formGrafica.TipoGrafica);
                        }
                        listaAux.Add(graficaAux);
                    }
                    respuesta = MessageBox.Show("Instalar otra grafica??", "Elija", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            } while (respuesta == DialogResult.Yes);

            servidorAux = new MineroBitcoin(listaAux);
            if (listaAux.Count > 0)
            {
                try
                {
                    sqlAlmacen.CargarMineroADataTable(servidorAux);
                    ActualizarGrillas();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
            else
            {
                MessageBox.Show("Nada que agregar...");
            }
        }
        #endregion

        #region serializarXML/deserializarXML y guardar/cargar Texto
        private void btnGuardarTxt_Click(object sender, EventArgs e)
        {
            try
            {
                this.SqlAMemoria();
                GuardarYSerializar.GuardarTexto($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/FabricaDepositoText.txt", miFabrica);
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
        private void btnCargarTexto_Click(object sender, EventArgs e)
        {
            try
            {
                FormMostrar formMostrar = new FormMostrar();
                formMostrar.TextBoxMostrar = GuardarYSerializar.LeerTexto($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/FabricaDepositoText.txt");
                formMostrar.Show();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                this.SqlAMemoria();
                GuardarYSerializar.SerializarXML($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/FabricaDepositoXML.xml", miFabrica);
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
        /// <summary>
        /// Carga el archivo XML a memoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            try
            {
                miFabrica = GuardarYSerializar.DeSerializarXML<TiposElectronicos>($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/FabricaDepositoXML.xml");
                sqlAlmacen.CargarAlmacenADataTable<TiposElectronicos>(miFabrica);
                ActualizarGrillas();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
        /// <summary>
        /// Actualiza las grillas con el DataTable
        /// </summary>
        private void ActualizarGrillas()
        {
            this.dataGridViewAlmacen.DataSource = sqlAlmacen.dtAlmacen;
            this.dataGridViewGrafica.DataSource = sqlAlmacen.dtGrafica;
            this.dataGridViewProcesador.DataSource = sqlAlmacen.dtProcesador;
        }
        #endregion

        #region Boton Mostrar,Borrar,Guardar y Cargar SQL 
        /// <summary>
        /// Muestra en un Txtbox lo guardado en memoria...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.SqlAMemoria();
                Thread t = new Thread(SqlAMemoria);
                t.Start();
                Thread.Sleep(50);
                FormMostrar formMostrar = new FormMostrar(miFabrica);

                formMostrar.Show();
                t.Abort();
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }
        /// <summary>
        /// borra la fila seleccionada del DataTable y los componentes(Procesador/es , Grafica/s) que lo acompañan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAlmacen.Rows.Count > 0)
                {
                    ActualizarGrillas();
                    sqlAlmacen.BorrarSQl(this.dataGridViewAlmacen.SelectedRows[0].Index);
                    ActualizarGrillas();
                    if(dataGridViewAlmacen.Rows.Count>0)
                        dataGridViewAlmacen.Rows[dataGridViewAlmacen.Rows.Count-1].Selected = true;
                }
                else
                { MessageBox.Show("Nada que borrar..."); }
            }
            catch (Exception s)
            {
               MessageBox.Show(s.Message);
               ActualizarGrillas();
            }
        }
        /// <summary>
        /// Guarda la info de la grilla al SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarSQL_Click(object sender, EventArgs e)
        {
            try
            {
                sqlAlmacen.GuardarSQL();
            }
            catch (Exception s)
            {
               MessageBox.Show(s.Message);
            }
        }
        /// <summary>
        /// Carga del SQL a la grilla y las actualiza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarSql_Click(object sender, EventArgs e)
        {
            try
            {
                sqlAlmacen.CargarSql();
                ActualizarGrillas();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }
        #endregion

        #region SqlAMemoria metodo 
        private void SqlAMemoria()
        {
            miFabrica = new FabricaDeposito<TiposElectronicos>(100);
            foreach (DataRow dataRow in sqlAlmacen.dtAlmacen.Rows)
            {
                if(dataRow.RowState!=DataRowState.Deleted)
                {
                    try
                    {
                        if ((string)dataRow[1] == "Computadora")
                        {
                            Computadora computadora;
                            Procesador procesador = null;
                            Grafica grafica = null;
                            foreach (DataRow dataRowProcesadores in sqlAlmacen.dtProcesador.Rows)
                            {
                                if ((int)dataRowProcesadores["AlmacenId"] == (int)dataRow["id"])
                                {
                                    Int32.TryParse(dataRowProcesadores[3].ToString(), out int cores);
                                    Enum.TryParse(dataRowProcesadores[4].ToString(), out Procesador.MarcaProcesador marca);
                                    Enum.TryParse(dataRowProcesadores[5].ToString(), out Procesador.Generacion generacion);
                                    float.TryParse(dataRowProcesadores[6].ToString(), out float precio);
                                    Enum.TryParse(dataRowProcesadores[7].ToString(), out Procesador.GamaProducto gama);
                                    Enum.TryParse(dataRowProcesadores[8].ToString(), out Procesador.TipoProducto tipo);
                                    procesador = new Procesador(dataRowProcesadores[1].ToString(), cores, marca, generacion, precio, gama, tipo);
                                }
                            }
                            foreach (DataRow dataRowGraficas in sqlAlmacen.dtGrafica.Rows)
                            {
                                if ((int)dataRowGraficas["AlmacenId"] == (int)dataRow["id"])
                                {
                                    Int32.TryParse(dataRowGraficas[3].ToString(), out int cores);
                                    Enum.TryParse(dataRowGraficas[4].ToString(), out Grafica.MarcaGrafica marca);
                                    float.TryParse(dataRowGraficas[5].ToString(), out float precio);
                                    Enum.TryParse(dataRowGraficas[6].ToString(), out Grafica.GamaProducto gama);
                                    Enum.TryParse(dataRowGraficas[7].ToString(), out Grafica.TipoProducto tipo);

                                    grafica = new Grafica(dataRowGraficas[1].ToString(), cores, marca, precio, gama, tipo);
                                }
                            }
                            if (!ReferenceEquals(grafica, null))
                            {
                                computadora = new Computadora(procesador, grafica);
                            }
                            else { computadora = new Computadora(procesador); }
                            miFabrica += computadora;
                        }
                        else if ((string)dataRow[1] == "Servidor")
                        {
                            Servidor servidor;
                            List<Procesador> lista = new List<Procesador>();
                            foreach (DataRow dataRowProcesadores in sqlAlmacen.dtProcesador.Rows)
                            {
                                if ((int)dataRowProcesadores["AlmacenId"] == (int)dataRow["id"])
                                {
                                    Int32.TryParse(dataRowProcesadores[3].ToString(), out int cores);
                                    Enum.TryParse(dataRowProcesadores[4].ToString(), out Procesador.MarcaProcesador marca);
                                    Enum.TryParse(dataRowProcesadores[5].ToString(), out Procesador.Generacion generacion);
                                    float.TryParse(dataRowProcesadores[6].ToString(), out float precio);
                                    Enum.TryParse(dataRowProcesadores[7].ToString(), out Procesador.GamaProducto gama);
                                    Enum.TryParse(dataRowProcesadores[8].ToString(), out Procesador.TipoProducto tipo);
                                    Procesador procesador = new Procesador(dataRowProcesadores[1].ToString(), cores, marca, generacion, precio, gama, tipo);
                                    lista.Add(procesador);
                                }
                            }
                            servidor = new Servidor(lista);
                            miFabrica += servidor;
                        }
                        else if ((string)dataRow[1] == "MineroBitcoin")
                        {
                            MineroBitcoin minero;
                            List<Grafica> lista = new List<Grafica>();
                            foreach (DataRow dataRowGraficas in sqlAlmacen.dtGrafica.Rows)
                            {
                                if ((int)dataRowGraficas["Almacenid"] == (int)dataRow["id"])
                                {
                                    Int32.TryParse(dataRowGraficas[3].ToString(), out int cores);
                                    Enum.TryParse(dataRowGraficas[4].ToString(), out Grafica.MarcaGrafica marca);
                                    float.TryParse(dataRowGraficas[5].ToString(), out float precio);
                                    Enum.TryParse(dataRowGraficas[6].ToString(), out Grafica.GamaProducto gama);
                                    Enum.TryParse(dataRowGraficas[7].ToString(), out Grafica.TipoProducto tipo);

                                    Grafica grafica = new Grafica(dataRowGraficas[1].ToString(), cores, marca, precio, gama, tipo);
                                    lista.Add(grafica);
                                }
                            }
                            minero = new MineroBitcoin(lista);
                            miFabrica += minero;
                        }
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);
                    }
                }
                
            }
        }
        #endregion
    }
}
