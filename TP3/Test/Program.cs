using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafica g1 = new Grafica("GT-1030", 2,4, Grafica.MarcaGrafica.NVIDIA, 1000, Producto.GamaProducto.Baja, Producto.TipoProducto.Comun);
            Grafica g2 = new Grafica("GTX 2050", 4,8, Grafica.MarcaGrafica.NVIDIA, 3000, Producto.GamaProducto.Media, Producto.TipoProducto.Gamer);
            Grafica g4 = new Grafica("Shinji44", 8, 16, Grafica.MarcaGrafica.Blanca, 8000, Producto.GamaProducto.Alta, Producto.TipoProducto.Industrial);

            Procesador p1 = new Procesador("i3-7100",3,4,Procesador.MarcaProcesador.Intel,Procesador.Generacion.Gen7,500,Producto.GamaProducto.Baja,Producto.TipoProducto.Comun);
            Procesador p2 = new Procesador("Beijing9000", 6, 16, Procesador.MarcaProcesador.Blanca, Procesador.Generacion.Otro, 5000, Producto.GamaProducto.Alta, Producto.TipoProducto.Industrial);
            Procesador p3 = new Procesador("Ryzen 5", 3, 8, Procesador.MarcaProcesador.AMD, Procesador.Generacion.Gen5,1000, Producto.GamaProducto.Media, Producto.TipoProducto.Gamer);

            Computadora c1 = new Computadora(p1, g1);
            Computadora c2 = new Computadora(p2);

            List<Grafica> auxList = new List<Grafica>();
            auxList.Add(g2);
            auxList.Add(g4);
            MineroBitcoin m1 = new MineroBitcoin(auxList);

            List<Procesador> auxList2 = new List<Procesador>();
            auxList2.Add(p1);
            auxList2.Add(p3);
            Servidor s1 = new Servidor(auxList2, 50);

            FabricaDeposito<Computadora> f1 = new FabricaDeposito<Computadora>(5);
            f1.Agregar(c1);
            f1.Agregar(c2);
            FabricaDeposito<MineroBitcoin> f2 = new FabricaDeposito<MineroBitcoin>(2);
            f2.Agregar(m1);
            FabricaDeposito<Servidor> f3 = new FabricaDeposito<Servidor>(1);
            f3.Agregar(s1);

            Console.Write(c1.ToString());
            Console.Write(c2.ToString());
            Console.Write(m1.ToString());

            Console.Write(f1.ToString());
            Console.Write(f2.ToString());
            Console.Write(f3.ToString());
            Console.ReadKey();
        }
    }
}
