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
        public void GuardarTexto(string archivo,object guardado)
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
                Console.WriteLine("Error al guardar");
            }

        }
        public string LeerTexto(string path)
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
                Console.WriteLine("Error al leer");
            }
            return aux;
        }
        public void SerializarXML<T>(string path) where T : FabricaDeposito<T>
        {
            try
            {
                FabricaDeposito<T> p = new FabricaDeposito<T>();
                XmlSerializer ser = new XmlSerializer(typeof(FabricaDeposito<T>));
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
                ser.Serialize(writer, p);
                writer.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al serializar");
            }
        }
        public void DeSerializarXML<T>(string path) where T : FabricaDeposito<T>
        {
            try 
            {
                FabricaDeposito<T> aux = new FabricaDeposito<T>();
                XmlTextReader reader = new XmlTextReader(path); //Objeto que leerá XML.
                XmlSerializer ser = new XmlSerializer(typeof(FabricaDeposito<T>)); //Objeto que Deserializará.
                aux = (FabricaDeposito<T>)ser.Deserialize(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al deserializar");
            }

        }
    }
}

