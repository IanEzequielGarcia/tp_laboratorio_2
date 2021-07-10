using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace Entidades
{
    public delegate void Delegado(object sender, EventArgs e);
    public class SQLAlmacen
    {
        public event Delegado EventoDelegado;

        public SqlConnection cn;

        public SqlDataAdapter daAlmacen;
        public SqlDataAdapter daProcesador;
        public SqlDataAdapter daGrafica;

        public DataTable dtAlmacen;
        public DataTable dtProcesador;
        public DataTable dtGrafica;
        public SQLAlmacen()
        {
            this.EventoDelegado += new Delegado(this.InicializarTodo);

            if (!ReferenceEquals(EventoDelegado,null))
            {
                this.EventoDelegado(null, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Inicializa el DataTable y DataAdapter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InicializarTodo(object sender, EventArgs e)
        {
            this.ConfigurarDataTables();
            this.ConfigurarDataAdapterAlmacen();
            this.ConfigurarDataAdapterGrafica();
            this.ConfigurarDataAdapterProcesador();
        }
        public void CargarAlmacenADataTable<T>(FabricaDeposito<TiposElectronicos> fabricaDeposito)
        {
            foreach(TiposElectronicos tiposElectronicos in fabricaDeposito.Lista)
            {
                switch(tiposElectronicos.GetType().Name)
                {
                    case "Computadora":
                        this.CargarComputadoraADataTable((Computadora)tiposElectronicos);
                        break;
                    case "Servidor":
                        this.CargarServidorADataTable((Servidor)tiposElectronicos);
                        break;
                    case "MineroBitcoin":
                        this.CargarMineroADataTable((MineroBitcoin)tiposElectronicos);
                        break;

                }
            }
        }
        /// <summary>
        /// Carga el Servidor ingresada al Datatable
        /// </summary>
        /// <param name="servidor"></param>
        /// <param name="AlmacenId"></param>
        /// <returns>bool</returns>
        public void CargarServidorADataTable(Servidor servidor)
        {
            try
            {
                DataRow dataRow = dtAlmacen.NewRow();
                dataRow[0] = dtAlmacen.Rows.Count;
                dataRow[1] = "Servidor";
                foreach (Procesador procesadores in servidor.Procesadores)
                {
                    if ((Procesador.Validar(procesadores)))
                    {
                        CargarProcesador(procesadores, (int)dataRow[0]);
                    }
                }
                dtAlmacen.Rows.Add(dataRow);
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Carga el MineroBitcoin ingresada al Datatable
        /// </summary>
        /// <param name="minero"></param>
        /// <param name="AlmacenId"></param>
        /// <returns>bool</returns>
        public void CargarMineroADataTable(MineroBitcoin minero)
        {
            try
            {
                DataRow dataRow = dtAlmacen.NewRow();
                dataRow[0] = dtAlmacen.Rows.Count;
                dataRow[1] = "MineroBitcoin";
                foreach (Grafica grafica in minero.Minadores)
                {
                    if ((Grafica.Validar(grafica)) && grafica.Modelo != "Sin grafica")
                    {
                        CargarGrafica(grafica, (int)dataRow[0]);
                    }
                }
                dtAlmacen.Rows.Add(dataRow);
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Carga la Computadora ingresada al Datatable
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="AlmacenId"></param>
        /// <returns>bool</returns>
        public void CargarComputadoraADataTable(Computadora pc)
        {
            try
            {
                DataRow dataRow = dtAlmacen.NewRow();
                dataRow[0] = dtAlmacen.Rows.Count;
                dataRow[1] = "Computadora";
                if ((Procesador.Validar(pc.ElProcesador)))
                {
                    CargarProcesador(pc.ElProcesador, (int)dataRow[0]);
                }
                if ((Grafica.Validar(pc.Lagrafica)) && pc.Lagrafica.Modelo != "Sin grafica")
                {
                    CargarGrafica(pc.Lagrafica, (int)dataRow[0]);
                }
                dtAlmacen.Rows.Add(dataRow);
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Carga la grafica ingresada al Datatable
        /// </summary>
        /// <param name="grafica"></param>
        /// <param name="AlmacenId"></param>
        /// <returns>bool</returns>
        public bool CargarGrafica(Grafica grafica, int AlmacenId)
        {
            try
            {
                DataRow dataRow = dtGrafica.NewRow();
                dataRow["Modelo"] = grafica.Modelo;
                dataRow["Hercio"] = grafica.Hercio;
                dataRow["Cores"] = grafica.Cores;
                dataRow["MarcaGrafica"] = grafica.Marca.ToString();
                dataRow["PrecioFabricacion"] = grafica.CosteProduccion;
                dataRow["Gama"] = grafica.Gama.ToString();
                dataRow["Tipo"] = grafica.Tipo.ToString();
                dataRow["AlmacenId"] = AlmacenId;

                dtGrafica.Rows.Add(dataRow);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Carga el procesador ingresada al Datatable
        /// </summary>
        /// <param name="grafica"></param>
        /// <param name="AlmacenId"></param>
        /// <returns>bool</returns>
        public bool CargarProcesador(Procesador procesador, int AlmacenId)
        {
            try
            {
                DataRow dataRow = dtProcesador.NewRow();
                dataRow["Modelo"] = procesador.Modelo;
                dataRow["Hercio"] = procesador.Hercio;
                dataRow["Cores"] = procesador.Cores;
                dataRow["MarcaProcesadores"] = procesador.MarcaProcesadores.ToString();
                dataRow["Generacion"] = procesador.Gen.ToString();
                dataRow["PrecioFabricacion"] = procesador.CosteProduccion;
                dataRow["Gama"] = procesador.Gama.ToString();
                dataRow["Tipo"] = procesador.Tipo.ToString();
                dataRow["AlmacenId"] = AlmacenId;

                dtProcesador.Rows.Add(dataRow);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Configura los DataTables
        /// </summary>
        public void ConfigurarDataTables()
        {
            this.dtAlmacen = new DataTable("Almacen");
            this.dtAlmacen.Columns.Add("id", typeof(int));
            this.dtAlmacen.Columns.Add("tipo", typeof(string));
            this.dtAlmacen.Columns["id"].AutoIncrement = true;
            this.dtAlmacen.Columns["id"].AutoIncrementSeed = 1;
            this.dtAlmacen.Columns["id"].AutoIncrementStep = 1;

            this.dtProcesador = new DataTable("Procesador");
            this.dtProcesador.Columns.Add("id", typeof(int));
            this.dtProcesador.Columns["id"].AutoIncrement = true;
            this.dtProcesador.Columns["id"].AutoIncrementSeed = 1;
            this.dtProcesador.Columns["id"].AutoIncrementStep = 1;
            this.dtProcesador.Columns.Add("Modelo", typeof(string));
            this.dtProcesador.Columns.Add("Hercio", typeof(float));
            this.dtProcesador.Columns.Add("Cores", typeof(int));
            this.dtProcesador.Columns.Add("MarcaProcesadores", typeof(string));
            this.dtProcesador.Columns.Add("Generacion", typeof(string));
            this.dtProcesador.Columns.Add("PrecioFabricacion", typeof(float));
            this.dtProcesador.Columns.Add("Gama", typeof(string));
            this.dtProcesador.Columns.Add("Tipo", typeof(string));
            this.dtProcesador.Columns.Add("AlmacenId", typeof(int));

            this.dtGrafica = new DataTable("Grafica");
            this.dtGrafica.Columns.Add("id", typeof(int));
            this.dtGrafica.Columns["id"].AutoIncrement = true;
            this.dtGrafica.Columns["id"].AutoIncrementSeed = 1;
            this.dtGrafica.Columns["id"].AutoIncrementStep = 1;
            this.dtGrafica.Columns.Add("Modelo", typeof(string));
            this.dtGrafica.Columns.Add("Hercio", typeof(float));
            this.dtGrafica.Columns.Add("Cores", typeof(int));
            this.dtGrafica.Columns.Add("MarcaGrafica", typeof(string));
            this.dtGrafica.Columns.Add("PrecioFabricacion", typeof(float));
            this.dtGrafica.Columns.Add("Gama", typeof(string));
            this.dtGrafica.Columns.Add("Tipo", typeof(string));
            this.dtGrafica.Columns.Add("AlmacenId", typeof(int));
        }
        /// <summary>
        /// Configura los comandos(select,delete,update,insert) del SqlDataAdapter, y conecta SqlConnection
        /// </summary>
        public void ConfigurarDataAdapterAlmacen()
        {
            try
            {
                this.daAlmacen = new SqlDataAdapter();

                this.cn = new SqlConnection(Properties.Settings.Default.conexion);

                //Almacen
                this.daAlmacen.SelectCommand = new SqlCommand("SELECT id,tipo FROM Almacen", this.cn);
                this.daAlmacen.InsertCommand = new SqlCommand("INSERT INTO Almacen (tipo) VALUES (@tipo)", this.cn);
                this.daAlmacen.UpdateCommand = new SqlCommand("UPDATE Almacen SETtipo=@tipo,WHERE id=@id", this.cn);
                this.daAlmacen.DeleteCommand = new SqlCommand("DELETE FROM Almacen WHERE id=@id", this.cn);
                this.daAlmacen.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daAlmacen.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
                this.daAlmacen.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daAlmacen.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Configura los comandos(select,delete,update,insert) del SqlDataAdapter
        /// </summary>
        public void ConfigurarDataAdapterGrafica()
        {
            //Grafica
            try
            {
                this.daGrafica = new SqlDataAdapter();

                this.daGrafica.SelectCommand = new SqlCommand("SELECT id,Modelo,Hercio,Cores,MarcaGrafica,PrecioFabricacion,Gama,Tipo,AlmacenId FROM Grafica", this.cn);
                this.daGrafica.InsertCommand = new SqlCommand("INSERT INTO Grafica (Modelo,Hercio,Cores,MarcaGrafica,PrecioFabricacion,Gama,Tipo,AlmacenId) " +
                    "VALUES (@Modelo,@Hercio,@Cores,@MarcaGrafica,@PrecioFabricacion,@Gama,@Tipo,@AlmacenId)", this.cn);
                this.daGrafica.UpdateCommand = new SqlCommand("UPDATE Grafica SET Modelo=@Modelo,Hercio=@Hercio,Cores=@Cores,MarcaGrafica=@MarcaGrafica," +
                    "PrecioFabricacion=@PrecioFabricacion,Gama=@Gama,Tipo=@Tipo,AlmacenId=@Almacenid WHERE id=@id", this.cn);
                this.daGrafica.DeleteCommand = new SqlCommand("DELETE FROM Grafica WHERE id=@id", this.cn);

                this.daGrafica.InsertCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50, "Modelo");
                this.daGrafica.InsertCommand.Parameters.Add("@Hercio", SqlDbType.Float, 50, "Hercio");
                this.daGrafica.InsertCommand.Parameters.Add("@Cores", SqlDbType.Int, 50, "Cores");
                this.daGrafica.InsertCommand.Parameters.Add("@MarcaGrafica", SqlDbType.VarChar, 50, "MarcaGrafica");
                this.daGrafica.InsertCommand.Parameters.Add("@PrecioFabricacion", SqlDbType.Float, 50, "PrecioFabricacion");
                this.daGrafica.InsertCommand.Parameters.Add("@Gama", SqlDbType.VarChar, 50, "Gama");
                this.daGrafica.InsertCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.daGrafica.InsertCommand.Parameters.Add("@AlmacenId", SqlDbType.Int, 50, "AlmacenId");

                this.daGrafica.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.daGrafica.UpdateCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50, "Modelo");
                this.daGrafica.UpdateCommand.Parameters.Add("@Hercio", SqlDbType.Float, 50, "Hercio");
                this.daGrafica.UpdateCommand.Parameters.Add("@Cores", SqlDbType.Int, 50, "Cores");
                this.daGrafica.UpdateCommand.Parameters.Add("@MarcaGrafica", SqlDbType.VarChar, 50, "MarcaGrafica");
                this.daGrafica.UpdateCommand.Parameters.Add("@PrecioFabricacion", SqlDbType.Float, 50, "PrecioFabricacion");
                this.daGrafica.UpdateCommand.Parameters.Add("@Gama", SqlDbType.VarChar, 50, "Gama");
                this.daGrafica.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.daGrafica.UpdateCommand.Parameters.Add("@AlmacenId", SqlDbType.Int, 10, "AlmacenId");

                this.daGrafica.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Configura los comandos(select,delete,update,insert) del SqlDataAdapter
        /// </summary>
        public void ConfigurarDataAdapterProcesador()
        {
            //Procesador
            try
            {
                this.daProcesador = new SqlDataAdapter();

                this.daProcesador.SelectCommand = new SqlCommand("SELECT id,Modelo,Hercio,Cores,MarcaProcesadores,Generacion,PrecioFabricacion,Gama,Tipo,AlmacenId FROM Procesador", this.cn);
                this.daProcesador.InsertCommand = new SqlCommand("INSERT INTO Procesador (Modelo,Hercio,Cores,MarcaProcesadores,Generacion,PrecioFabricacion,Gama,Tipo,AlmacenId) " +
                    "VALUES (@Modelo,@Hercio,@Cores,@MarcaProcesadores,@Generacion,@PrecioFabricacion,@Gama,@Tipo,@AlmacenId)", this.cn);
                this.daProcesador.UpdateCommand = new SqlCommand("UPDATE Procesador SET Modelo=@Modelo,Hercio=@Hercio,Cores=@Cores,MarcaProcesadores=@MarcaProcesadores," +
                    "Generacion=@Generacion,PrecioFabricacion=@PrecioFabricacion,Gama=@Gama,Tipo=@Tipo,AlmacenId=@AlmacenId WHERE id=@id", this.cn);
                this.daProcesador.DeleteCommand = new SqlCommand("DELETE FROM Procesador WHERE id=@id", this.cn);

                //this.daProcesador.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
                this.daProcesador.InsertCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50, "Modelo");
                this.daProcesador.InsertCommand.Parameters.Add("@Hercio", SqlDbType.Float, 50, "Hercio");
                this.daProcesador.InsertCommand.Parameters.Add("@Cores", SqlDbType.Int, 50, "Cores");
                this.daProcesador.InsertCommand.Parameters.Add("@MarcaProcesadores", SqlDbType.VarChar, 50, "MarcaProcesadores");
                this.daProcesador.InsertCommand.Parameters.Add("@Generacion", SqlDbType.VarChar, 50, "Generacion");
                this.daProcesador.InsertCommand.Parameters.Add("@PrecioFabricacion", SqlDbType.Float, 50, "PrecioFabricacion");
                this.daProcesador.InsertCommand.Parameters.Add("@Gama", SqlDbType.VarChar, 50, "Gama");
                this.daProcesador.InsertCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.daProcesador.InsertCommand.Parameters.Add("@AlmacenId", SqlDbType.Int, 50, "AlmacenId");

                this.daProcesador.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
                this.daProcesador.UpdateCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50, "Modelo");
                this.daProcesador.UpdateCommand.Parameters.Add("@Hercio", SqlDbType.Float, 50, "Hercio");
                this.daProcesador.UpdateCommand.Parameters.Add("@Cores", SqlDbType.Int, 50, "Cores");
                this.daProcesador.UpdateCommand.Parameters.Add("@MarcaProcesadores", SqlDbType.VarChar, 50, "MarcaProcesadores");
                this.daProcesador.UpdateCommand.Parameters.Add("@Generacion", SqlDbType.VarChar, 50, "Generacion");
                this.daProcesador.UpdateCommand.Parameters.Add("@PrecioFabricacion", SqlDbType.Float, 50, "PrecioFabricacion");
                this.daProcesador.UpdateCommand.Parameters.Add("@Gama", SqlDbType.VarChar, 50, "Gama");
                this.daProcesador.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.daProcesador.UpdateCommand.Parameters.Add("@AlmacenId", SqlDbType.Int, 50, "AlmacenId");

                this.daProcesador.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 50, "id");
            }
            catch (Exception e)
            {
                throw new Excepciones(e.Message);
            }
        }
        /// <summary>
        /// Carga los datos del SQL al datagriview y lo actualiza
        /// </summary>
        public void CargarSql()
        {
            try
            {
                this.daAlmacen.Fill(this.dtAlmacen);
                this.daGrafica.Fill(this.dtGrafica);
                this.daProcesador.Fill(this.dtProcesador);
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }
        }
        /// <summary>
        /// guarda los datos del dataTable directo al SQLServer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GuardarSQL()
        {
            try
            {
                this.daAlmacen.Update(this.dtAlmacen);
                this.daProcesador.Update(this.dtProcesador);
                this.daGrafica.Update(this.dtGrafica);
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }
        }
        /// <summary>
        /// borra la fila seleccionada del DataTable y los componentes(Procesador/es , Grafica/s) que lo acompañan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BorrarSQl(int indice)
        {
            try
            {
                int i = indice;
                i = this.dtAlmacen.Rows[i].Field<int>("id");
                this.dtAlmacen.Rows[indice].Delete();
                for(int x =0; x < this.dtProcesador.Rows.Count; x++)
                {
                    if(!ReferenceEquals(this.dtProcesador.Rows, null) && !ReferenceEquals(this.dtProcesador.Rows[x],null))
                    {
                        DataRow dataRow = this.dtProcesador.Rows[x];
                        if ((int)dataRow["AlmacenId"] == i)
                        {
                            dataRow.Delete();
                            x--; 
                        }
                    }
                    else { break; }

                }
                for (int x = 0; x < this.dtGrafica.Rows.Count; x++)
                {
                    if (!ReferenceEquals(this.dtGrafica.Rows, null)&&!ReferenceEquals(this.dtGrafica.Rows[x], null))
                    {
                        DataRow dataRow = this.dtGrafica.Rows[x];
                        if ((int)dataRow["AlmacenId"] == i)
                        {
                            dataRow.Delete();
                            x--; 
                        }
                    }
                    else { break; }
                }
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }

        }
    }
}
