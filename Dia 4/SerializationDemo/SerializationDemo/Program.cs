using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elija una opcion 1-3");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    BinarySerializable();
                        break;
                case '2':
                    XmlSerializable();
                        break;
                case '3':
                    JsonSerializable();
                    break;
                default:
                    break;
            }


          
        }

        static void BinarySerializable()
        {

            Console.WriteLine("binary Format");
            Console.WriteLine("Crear un objecto y guardarlo serializado");

            string filepath = "miObjecto.txt";

            IFormatter formatter = new BinaryFormatter();

            Comida pizza = new Comida() { Componente = "Maza, Queso, salda de tomate, tocino, aceite,aceituna", Nombre = "Especial" };

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, pizza);
            fs.Close();



            Console.ReadKey();


            fs = new FileStream(filepath, FileMode.Open);
            var c = (Comida)formatter.Deserialize(fs);

            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);

            fs.Close();

            File.Delete(filepath);

            Console.ReadKey();

        }

        static void XmlSerializable()
        {

            Console.WriteLine("Xml SOAP Format");
            Console.WriteLine("Crear un objecto y guardarlo serializado");

            string filepath = "miObjecto.xml";

            IFormatter formatter = new SoapFormatter();

            Comida pizza = new Comida() { Componente = "Maza, Queso, salda de tomate, tocino, aceite,aceituna", Nombre = "Especial" };

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, pizza);
            fs.Close();



            Console.ReadKey();


            fs = new FileStream(filepath, FileMode.Open);
            var c = (Comida)formatter.Deserialize(fs);

            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);

            fs.Close();

            File.Delete(filepath);

            Console.ReadKey();

        }

        static void JsonSerializable()
        {

            Console.WriteLine("Json Format");
            Console.WriteLine("Crear un objecto y guardarlo serializado");

            string filepath = "miObjecto.json";

            

            Comida pizza = new Comida() { Componente = "Maza, Queso, salda de tomate, tocino, aceite,aceituna", Nombre = "Especial" };

            string json = JsonConvert.SerializeObject(pizza);

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs)) {
                sw.WriteLine(json);                
            }
            fs.Close();



            Console.ReadKey();


            fs = new FileStream(filepath, FileMode.Open);
            string jsonstorage;
            using (StreamReader r = new StreamReader(fs)) {
                jsonstorage = r.ReadToEnd();
            }

            var c = JsonConvert.DeserializeObject<Comida>(jsonstorage);

            // Serializable JSON a XMl y Viceversa
            var trasnform = JsonConvert.DeserializeXmlNode(jsonstorage, "Comida");
            var result = JsonConvert.SerializeXmlNode(trasnform);
            // Serializable JSON a XMl y Viceversa


            Console.WriteLine(c.Componente);
            Console.WriteLine(c.Nombre);

            fs.Close();

            File.Delete(filepath);

            Console.ReadKey();

        }
    }

    [Serializable]
    public class Comida : ISerializable
    {

        //const string QWERTY = "Teclado";

        public string Componente { get; set; }
        public string Nombre { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("componente", Componente, typeof(string));
            info.AddValue("nombre", Nombre, typeof(string));
        }

        public Comida(SerializationInfo info, StreamingContext context)
        {
            Componente = (string)info.GetValue("componente", typeof(string));
            Nombre = (string)info.GetValue("nombre", typeof(string));
        }

        public Comida()
        {

        }
    }
}
