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
                throw new Exception(e.Message);
            }

        }
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
                throw new Exception(e.Message);
            }
            return aux;
        }
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
                throw new Exception(e.Message);
            }
        }
        public static FabricaDeposito<T> DeSerializarXML<T>(string path) where T : TiposElectronicos
        {
            try 
            {
                FabricaDeposito<T> aux = new FabricaDeposito<T>();
                XmlTextReader reader = new XmlTextReader(path);
                XmlSerializer ser = new XmlSerializer(typeof(FabricaDeposito<T>));
                aux = (FabricaDeposito<T>)ser.Deserialize(reader);
                reader.Close();
                return aux;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

