using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Entidades
{
    public class GuardarYSerializar
    {
        /// <summary>
        /// Guarda el objeto en modo txt en el path indicado
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="guardado"></param>
        public static void GuardarTexto(string archivo,object guardado)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine(guardado);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// Lee un archivo TXT y lo devuelve como string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LeerTexto(string path)
        {
            string aux="Nada para leer";
            try 
            {
                StreamReader sr = new StreamReader(path);
                aux = sr.ReadToEnd();
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return aux;
        }
        /// <summary>
        /// Serializa a XML el objeto ingresado y lo guarda en el path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ingresado"></param>
        public static void SerializarXML(string path, object ingresado)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(FabricaDeposito<TiposElectronicos>));
                    ser.Serialize(writer, ingresado);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Deseraliza una fabrica de Tipos electronicos y lo devuelve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FabricaDeposito<T> DeSerializarXML<T>(string path) where T : TiposElectronicos
        {
            FabricaDeposito<T> aux = new FabricaDeposito<T>();
            try 
            {
                
                XmlTextReader reader = new XmlTextReader(path);
                XmlSerializer ser = new XmlSerializer(typeof(FabricaDeposito<T>));
                aux = (FabricaDeposito<T>)ser.Deserialize(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return aux;
        }
    }
}

