using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;
namespace PruebaUnita
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Crea tipo Fabrica deposito,Computadora,Servidor y minador
        /// Los Agrega al deposito y chequea que se hayan agregado correctamente
        /// </summary>
        [TestMethod]
        public void AniadirDepositoFabrica()
        {
            //arrange
            int capacidad=3;
            FabricaDeposito<TiposElectronicos> fabrica = new FabricaDeposito<TiposElectronicos>(capacidad);
            Computadora c1 = new Computadora(new Procesador());
            Servidor s1 = new Servidor(new List<Procesador>());
            MineroBitcoin m1 = new MineroBitcoin(new List<Grafica>());
            //act
            fabrica += c1;
            fabrica += s1;
            fabrica += m1;
            //assert
            Assert.IsTrue(fabrica == c1);
            Assert.IsTrue(fabrica == s1);
            Assert.IsTrue(fabrica == m1);
        }
        /// <summary>
        /// Crea tipo Fabrica deposito,Computadora,Servidor y minador
        /// Los Agrega al deposito y chequea que se hayan agregado correctamente
        /// </summary>
        [TestMethod]
        public void BorrarDepositoFabrica()
        {
            //arrange
            int capacidad = 3;
            FabricaDeposito<TiposElectronicos> fabrica = new FabricaDeposito<TiposElectronicos>(capacidad);
            Computadora c1 = new Computadora(new Procesador());
            Servidor s1 = new Servidor(new List<Procesador>());
            MineroBitcoin m1 = new MineroBitcoin(new List<Grafica>());
            //act
            fabrica += c1;
            fabrica += s1;
            fabrica += m1;
            //assert
            Assert.IsTrue(fabrica == c1);
            Assert.IsTrue(fabrica == s1);
            Assert.IsTrue(fabrica == m1);
            fabrica -= c1;
            fabrica -= s1;
            fabrica -= m1;
            Assert.IsTrue(fabrica != c1);
            Assert.IsTrue(fabrica != s1);
            Assert.IsTrue(fabrica != m1);
        }
        /// <summary>
        /// Crea una clase grafica y comprueba que los parametros sean iguales
        /// </summary>
        [TestMethod]
        public void IsEqualGrafica()
        {
            //arrange
            string modelo = "GT-1030";
            int cores = 4;
            Grafica.MarcaGrafica marcaGrafica = Grafica.MarcaGrafica.NVIDIA;

            float costeProduccion = 1000;
            Producto.GamaProducto gama = Producto.GamaProducto.Baja;
            Producto.TipoProducto tipo = Producto.TipoProducto.Comun;
            //Act
            Grafica g1 = new Grafica("GT-1030", 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            //assert
            Assert.AreEqual(modelo, g1.Modelo);
            Assert.AreEqual(cores, g1.Cores);
            Assert.AreEqual(marcaGrafica, g1.Marca);
            Assert.AreEqual(costeProduccion, g1.CosteProduccion);
            Assert.AreEqual(gama, g1.Gama);
            Assert.AreEqual(tipo, g1.Tipo);
        }
        /// <summary>
        /// Crea una clase Procesador y comprueba que los parametros sean iguales
        /// </summary>
        [TestMethod]
        public void IsEqualProcesador()
        {
            //arrange
            string modelo = "i3-7100";
            int cores = 4;
            Procesador.MarcaProcesador marca = Procesador.MarcaProcesador.Intel;
            Procesador.Generacion generacion = Procesador.Generacion.Gen7;
            float costeProduccion = 500;
            Producto.GamaProducto gama = Producto.GamaProducto.Baja;
            Producto.TipoProducto tipo = Producto.TipoProducto.Comun;
            //Act
            Procesador p1 = new Procesador("i3-7100", 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            //assert
            Assert.AreEqual(modelo, p1.Modelo);
            Assert.AreEqual(cores, p1.Cores);
            Assert.AreEqual(marca, p1.MarcaProcesadores);
            Assert.AreEqual(generacion, p1.Gen);
            Assert.AreEqual(costeProduccion, p1.CosteProduccion);
            Assert.AreEqual(gama, p1.Gama);
            Assert.AreEqual(tipo, p1.Tipo);
        }
    }
}
