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
        #region Atributos 
        public event Delegado EventoDelegado;

        public SqlConnection cn;

        public SqlDataAdapter daAlmacen;
        public SqlDataAdapter daProcesador;
        public SqlDataAdapter daGrafica;

        public DataTable dtAlmacen;
        public DataTable dtProcesador;
        public DataTable dtGrafica;
        #endregion
        
        #region Constructor 
        public SQLAlmacen()
        {
            this.EventoDelegado += new Delegado(this.InicializarTodo);

            if (!ReferenceEquals(EventoDelegado,null))
            {
                this.EventoDelegado(null, EventArgs.Empty);
                this.cn = new SqlConnection(Properties.Settings.Default.conexion);
            }
        }
        #endregion

        #region Metodos Cargar a DataTable 
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
                if (dtAlmacen.Rows.Count > 0)
                {
                    dataRow[0] = BuscarMayorId() + 1;
                }
                else
                {
                    dataRow[0] = 1;
                }
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
                if (dtAlmacen.Rows.Count > 0)
                {
                    dataRow[0] = BuscarMayorId() + 1;
                }
                else
                {
                    dataRow[0] = 1;
                }
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
                if(dtAlmacen.Rows.Count>0)
                {
                    dataRow[0] = BuscarMayorId() + 1;
                }
                else
                {
                    dataRow[0] = 1;
                }
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
        /// Busca el mayor id en el dataTable Almacen y lo devuelve
        /// </summary>
        /// <returns></returns>
        public int BuscarMayorId()
        {
            int aux = 1;
            try
            {
                foreach (DataRow dataRow in dtAlmacen.Rows)
                {
                    if (dataRow.RowState != DataRowState.Deleted)
                    {
                        if ((int)dataRow["id"] > aux)
                        {
                            aux = (int)dataRow["id"];
                        }
                    }
                }
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }
            return aux;
        }
        #endregion

        #region Cargar Grafica y Procesador 
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
        #endregion

        #region Inicializar y Configurar
        /// <summary>
        /// Configura e inicializa los Datatables y Adapters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void InicializarTodo(object sender, EventArgs e)
        {
            try
            {
                this.ConfigurarDataTables();
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }
        }
        /// <summary>
        /// Configura los DataTables
        /// </summary>
        public void ConfigurarDataTables()
        {
            this.dtAlmacen = new DataTable("Almacen");
            this.dtAlmacen.Columns.Add("id", typeof(int));
            this.dtAlmacen.Columns["id"].AutoIncrement = true;
            this.dtAlmacen.Columns["id"].AutoIncrementSeed = 1;
            this.dtAlmacen.Columns["id"].AutoIncrementStep = 1;
            this.dtAlmacen.Columns.Add("tipo", typeof(string));

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
        #endregion

        #region Cargar Guardar y Borrar SQL 
        /// <summary>
        /// Carga los datos del SQL al datagriview y lo actualiza
        /// </summary>
        public void CargarSql()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Almacen", this.cn);
                sqlCommand.Connection = this.cn;
                this.cn.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int[] idAlmacenAux = new int[100];
                while (sqlDataReader.Read())
                {
                    DataRow dataRow = this.dtAlmacen.NewRow();
                    if (dtAlmacen.Rows.Count > 0)
                    {dataRow["id"] = dtAlmacen.Rows.Count+1; }
                    else
                    { dataRow["id"] = 1; }
                    idAlmacenAux[(int)sqlDataReader["id"]] =(int)dataRow["id"];
                    dataRow["tipo"] = sqlDataReader["tipo"].ToString();
                    dtAlmacen.Rows.Add(dataRow);
                }
                this.cn.Close();

                sqlCommand = new SqlCommand("SELECT * FROM Procesador", this.cn);
                sqlCommand.Connection = this.cn;
                this.cn.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DataRow dataRow = this.dtProcesador.NewRow();
                    dataRow["Modelo"] = sqlDataReader["Modelo"].ToString();
                    dataRow["Cores"] = (int)sqlDataReader["Cores"];
                    dataRow["Hercio"] = float.Parse(sqlDataReader["Hercio"].ToString());
                    dataRow["MarcaProcesadores"] = sqlDataReader["MarcaProcesadores"].ToString();
                    dataRow["Generacion"] = sqlDataReader["Generacion"].ToString();
                    dataRow["PrecioFabricacion"] = sqlDataReader["PrecioFabricacion"].ToString();
                    dataRow["Gama"] = sqlDataReader["Gama"].ToString();
                    dataRow["Tipo"] = sqlDataReader["Tipo"].ToString();
                    dataRow["AlmacenId"] = idAlmacenAux[(int)sqlDataReader["AlmacenId"]];
                    dtProcesador.Rows.Add(dataRow);
                }
                this.cn.Close();

                sqlCommand = new SqlCommand("SELECT * FROM Grafica", this.cn);
                sqlCommand.Connection = this.cn;
                this.cn.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DataRow dataRow = this.dtGrafica.NewRow();
                    dataRow["Modelo"] = sqlDataReader["Modelo"].ToString();
                    dataRow["Hercio"] = float.Parse(sqlDataReader["Hercio"].ToString());
                    dataRow["Cores"] = (int)sqlDataReader["Cores"];
                    dataRow["MarcaGrafica"] = sqlDataReader["MarcaGrafica"].ToString();
                    dataRow["PrecioFabricacion"] = sqlDataReader["PrecioFabricacion"].ToString();
                    dataRow["Gama"] = sqlDataReader["Gama"].ToString();
                    dataRow["Tipo"] = sqlDataReader["Tipo"].ToString();
                    dataRow["AlmacenId"] = idAlmacenAux[(int)sqlDataReader["AlmacenId"]];
                    dtGrafica.Rows.Add(dataRow);
                }
                this.cn.Close();
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
                try
                {
                    LimpiarSql();
                    GuardarAlmacenSQL();
                    GuardarGraficaSQL();
                    GuardarProcesadorSQL();
                }
                catch (Exception e)
                {
                    throw new Excepciones(e.Message);
                }
            }
            catch (Exception s)
            { 
                this.cn.Close();
                throw new Excepciones(s.Message);
            }
        
        }
        public void GuardarAlmacenSQL()
        {
            foreach (DataRow dataRow in dtAlmacen.Rows)
            {
                string comando = "INSERT INTO Almacen (id,tipo) VALUES (@id,@tipo)";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = comando;
                sqlCommand.Connection = this.cn;
                sqlCommand.Parameters.AddWithValue("@id", dataRow["id"]);
                sqlCommand.Parameters.AddWithValue("@tipo", dataRow["tipo"]);

                this.cn.Open();
                sqlCommand.ExecuteNonQuery();
                this.cn.Close();
            }
        }
        public void GuardarProcesadorSQL()
        {
            foreach (DataRow dataRow in dtProcesador.Rows)
            {
                string comando = "INSERT INTO Procesador (id,Modelo,Hercio,Cores,MarcaProcesadores,Generacion,PrecioFabricacion,Gama,Tipo,AlmacenId) " +
                    "VALUES (@id,@Modelo,@Hercio,@Cores,@MarcaProcesadores,@Generacion,@PrecioFabricacion,@Gama,@Tipo,@AlmacenId)";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = comando;
                sqlCommand.Connection = this.cn;
                sqlCommand.Parameters.AddWithValue("@id", dataRow["id"]);
                sqlCommand.Parameters.AddWithValue("@Modelo", dataRow["Modelo"]);
                sqlCommand.Parameters.AddWithValue("@Hercio", dataRow["Hercio"]);
                sqlCommand.Parameters.AddWithValue("@Cores", dataRow["Cores"]);
                sqlCommand.Parameters.AddWithValue("@MarcaProcesadores", dataRow["MarcaProcesadores"]);
                sqlCommand.Parameters.AddWithValue("@Generacion", dataRow["Generacion"]);
                sqlCommand.Parameters.AddWithValue("@PrecioFabricacion", dataRow["PrecioFabricacion"]);
                sqlCommand.Parameters.AddWithValue("@Gama", dataRow["Gama"]);
                sqlCommand.Parameters.AddWithValue("@Tipo", dataRow["Tipo"]);
                sqlCommand.Parameters.AddWithValue("@AlmacenId", dataRow["Almacenid"]);

                this.cn.Open();
                sqlCommand.ExecuteNonQuery();
                this.cn.Close();
            }
        }
        public void GuardarGraficaSQL()
        {
            foreach (DataRow dataRow in dtGrafica.Rows)
            {
                string comando = "INSERT INTO Grafica (id,Modelo,Hercio,Cores,MarcaGrafica,PrecioFabricacion,Gama,Tipo,AlmacenId) " +
                                   "VALUES (@id,@Modelo,@Hercio,@Cores,@MarcaGrafica,@PrecioFabricacion,@Gama,@Tipo,@AlmacenId)";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = comando;
                sqlCommand.Connection = this.cn;
                sqlCommand.Parameters.AddWithValue("@id", dataRow["id"]);
                sqlCommand.Parameters.AddWithValue("@Modelo", dataRow["Modelo"]);
                sqlCommand.Parameters.AddWithValue("@Hercio", dataRow["Hercio"]);
                sqlCommand.Parameters.AddWithValue("@Cores", dataRow["Cores"]);
                sqlCommand.Parameters.AddWithValue("@MarcaGrafica", dataRow["MarcaGrafica"]);
                sqlCommand.Parameters.AddWithValue("@PrecioFabricacion", dataRow["PrecioFabricacion"]);
                sqlCommand.Parameters.AddWithValue("@Gama", dataRow["Gama"]);
                sqlCommand.Parameters.AddWithValue("@Tipo", dataRow["Tipo"]);
                sqlCommand.Parameters.AddWithValue("@AlmacenId", dataRow["Almacenid"]);

                this.cn.Open();
                sqlCommand.ExecuteNonQuery();
                this.cn.Close();
            }
        }
        /// <summary>
        /// Limpia todo lo que esta guardado en el SQL
        /// </summary>
        public void LimpiarSql()
        {
            try
            {
                dtAlmacen.AcceptChanges();
                dtProcesador.AcceptChanges();
                dtGrafica.AcceptChanges();
                
                string comando = "DELETE FROM Almacen;DELETE FROM Procesador;DELETE FROM Grafica";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = comando;
                sqlCommand.Connection = this.cn;
                this.cn.Open();
                sqlCommand.ExecuteNonQuery();
                this.cn.Close();
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
                if (this.dtAlmacen.Rows[i].RowState != DataRowState.Deleted)
                    i = this.dtAlmacen.Rows[i].Field<int>("id");
                else
                {
                    this.dtAlmacen.Rows[i].AcceptChanges();
                }
                for (int x =0; x < this.dtProcesador.Rows.Count; x++)
                {
                    if(!ReferenceEquals(this.dtProcesador.Rows, null) && !ReferenceEquals(this.dtProcesador.Rows[x],null))
                    {
                        DataRow dataRow = this.dtProcesador.Rows[x];
                        if (dataRow.RowState != DataRowState.Deleted)
                        {
                            if((int)dataRow["AlmacenId"] == i)
                            {
                                dataRow.Delete();
                                x--;
                            }
                        }
                        else {
                            dataRow.AcceptChanges();
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
                        if (dataRow.RowState != DataRowState.Deleted)
                        {
                            if ((int)dataRow["AlmacenId"] == i)
                            {
                                dataRow.Delete();
                                x--;
                            }
                        }
                        else { 
                            dataRow.AcceptChanges();
                            x--;
                        }
                    }
                    else { break; }
                }
                this.dtAlmacen.Rows[indice].Delete();
                dtGrafica.AcceptChanges();
                dtProcesador.AcceptChanges();
                dtAlmacen.AcceptChanges();
            }
            catch (Exception s)
            {
                throw new Excepciones(s.Message);
            }
        }
        #endregion
    }
}
