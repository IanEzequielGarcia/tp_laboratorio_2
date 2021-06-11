using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsEqualGrafica()
        {
            //arrange
            string modelo= "GT-1030";
            float hercio= 2;
            int cores = 4;
            float costeProduccion=1000;
            Producto.GamaProducto gama = Producto.GamaProducto.Baja;
            Producto.TipoProducto tipo = Producto.TipoProducto.Comun;
            //Act
            Grafica g1 = new Grafica("GT-1030", 2, 4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            //assert
            Assert.AreEqual(modelo, g1.Modelo);
            Assert.AreEqual(hercio, g1.Hercio);
            Assert.AreEqual(cores, g1.Cores);
            Assert.AreEqual(costeProduccion, g1.CosteProduccion);
            Assert.AreEqual(gama, g1.Gama);
            Assert.AreEqual(tipo, g1.Tipo);
        }

        [TestMethod]
        public void IsEqualProcesador()
        {
            //arrange
            string modelo = "i3-7100";
            float hercio = 3;
            int cores = 4;
            Procesador.MarcaProcesador marca = Procesador.MarcaProcesador.Intel;
            Procesador.Generacion generacion = Procesador.Generacion.Gen7;
            float costeProduccion = 500;
            Producto.GamaProducto gama = Producto.GamaProducto.Baja;
            Producto.TipoProducto tipo = Producto.TipoProducto.Comun;
            //Act
            Procesador p1 = new Procesador("i3-7100", 3, 4, Procesador.MarcaProcesador.Intel, Procesador.Generacion.Gen7, 500, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            //assert
            Assert.AreEqual(modelo, p1.Modelo);
            Assert.AreEqual(hercio, p1.Hercio);
            Assert.AreEqual(marca, p1.MarcaProcesadores);
            Assert.AreEqual(generacion, p1.Gen);

            Assert.AreEqual(cores, p1.Cores);
            Assert.AreEqual(costeProduccion, p1.CosteProduccion);
            Assert.AreEqual(gama, p1.Gama);
            Assert.AreEqual(tipo, p1.Tipo);
        }
    }
}
