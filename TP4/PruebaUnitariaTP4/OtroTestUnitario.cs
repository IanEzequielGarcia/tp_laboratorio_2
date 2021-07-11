using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

using Entidades;
namespace PruebaUnitariaTP4
{
    [TestClass]
    public class OtroTestUnitario
    {
        /// <summary>
        /// TESTEA QUE LO GUARDADO EN TEXTO SEA LO MISMO
        /// </summary>
        [TestMethod]
        public void TestArchivosTexto()
        {
            /* TESTS UNITARIOS TP4 NUEVOS */
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Computadora computadora = new Computadora(p1, g1);
            FabricaDeposito<TiposElectronicos> fabrica = new FabricaDeposito<TiposElectronicos>(5);
            fabrica.Agregar(computadora);

            GuardarYSerializar.GuardarTexto("TestArchivo.txt", fabrica);
            string aux = GuardarYSerializar.LeerTexto("TestArchivo.txt");
            string aux2 = fabrica.ToString();
            try
            {
                Assert.IsTrue(
                       string.Compare(aux, aux2) == 0
                       );
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// TESTEA QUE LO GUARDADO EN XML SEA LO MISMO
        /// </summary>
        [TestMethod]
        public void TestArchivosXML()
        {
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Computadora computadora = new Computadora(p1, g1);
            FabricaDeposito<TiposElectronicos> fabrica = new FabricaDeposito<TiposElectronicos>(5);
            fabrica.Agregar(computadora);

            FabricaDeposito<TiposElectronicos> fabricaAux = new FabricaDeposito<TiposElectronicos>(5);
            GuardarYSerializar.SerializarXML("TestArchivoXML.xml", fabrica);
            fabricaAux = GuardarYSerializar.DeSerializarXML<TiposElectronicos>("TestArchivoXML.xml");
            try
            {
                Assert.IsTrue(
                        string.Compare(fabrica.ToString(), fabricaAux.ToString()) == 0
                       );
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// CONFIRMA QUE LA EXCEPCION "YA ESTA INGRESADO EN EL DEPOSITO" FUNCIONE CORRECTAMENTE
        /// </summary>
        [TestMethod]
        public void TestYaIngresadoException()
        {
            FabricaDeposito<TiposElectronicos> fabrica = new FabricaDeposito<TiposElectronicos>(2);
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Computadora computadora = new Computadora(p1, g1);
            bool aux = false;

            fabrica += computadora;
            try
            {
                fabrica += computadora;
            }
            catch (Excepciones)
            {
                aux = true;
            }
            Assert.IsTrue(aux);
        }
        /// <summary>
        /// Confirma que los tres Tipos Electronicos (computadora,servidor,minerobitcoin) se hayan ingresado al DataTable correctamente
        /// </summary>
        [TestMethod]
        public void TestDataTableIngresoCantidad()
        {
            SQLAlmacen sQLAlmacen = new SQLAlmacen();
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Computadora computadora1 = new Computadora(p1, g1);
            Servidor servidor1 = new Servidor(new List<Procesador>());
            MineroBitcoin minero1 = new MineroBitcoin(new List<Grafica>());

            FabricaDeposito<TiposElectronicos> deposito1 = new FabricaDeposito<TiposElectronicos>(3);
            bool aux;
            try
            {
                deposito1.Agregar(computadora1);
                deposito1.Agregar(servidor1);
                deposito1.Agregar(minero1);

                sQLAlmacen.CargarAlmacenADataTable<TiposElectronicos>(deposito1);

                sQLAlmacen.CargarProcesador(p1, 1);
                sQLAlmacen.CargarGrafica(g1, 2);
                aux = sQLAlmacen.dtAlmacen.Rows.Count == 3;
            }
            catch (Exception)
            {
                aux = false;
            }
            Assert.IsTrue(aux);
        }
        /// <summary>
        /// Confirma que los datos se hayan cargado correctamente al datatable
        /// </summary>
        public void TestIsEqualDataTable()
        {
            SQLAlmacen sQLAlmacen = new SQLAlmacen();
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Computadora computadora1 = new Computadora(p1, g1);
            FabricaDeposito<TiposElectronicos> deposito1 = new FabricaDeposito<TiposElectronicos>(3);

            deposito1.Agregar(computadora1);
            sQLAlmacen.CargarAlmacenADataTable<TiposElectronicos>(deposito1);

            DataRow dataRowProcesador = sQLAlmacen.dtProcesador.Rows[0];
            DataRow dataRowGrafica = sQLAlmacen.dtGrafica.Rows[0];

        }
    }
}

