using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFileDP
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            string newDirectory = $"{currentDirectory}/{DateTime.Now.Millisecond.ToString()}";
            Directory.CreateDirectory(newDirectory);


            string filePath = $"{currentDirectory}/Luis.txt";

            FileStream stream=null;

            if (!File.Exists(filePath))
            {
                File.Create(filePath,1024,FileOptions.RandomAccess);
            }

            // Stream
            try
            {
                if(stream == null) stream = File.Open(filePath, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(stream)) {


                    Console.WriteLine($"-----Stream Write---------");
                    sw.WriteLine("Hola Mundo!");
                    sw.WriteLine("Hola Clase!");

                    foreach (var v in Directory.GetDirectories(Directory.GetDirectoryRoot(currentDirectory)))
                    {
                        sw.WriteLine(v);
                    }
                }

            

            }
            catch (Exception)
            {
                throw;
            }
            finally {
                stream.Close();
            }


            using (FileStream fs = new FileStream(filePath, FileMode.Open,FileAccess.ReadWrite))
            {
                // throw new OutOfMemoryException();

                using (StreamReader r = new StreamReader(fs))
                {

                    Console.WriteLine($"-----Stream Reader---------");
                    Console.WriteLine(r.ReadToEnd());
                }
            }


            File.AppendAllText(filePath, "Hola mundo");
            var file = File.ReadAllLines(filePath);
                       

            Console.WriteLine($"---- Create File & Append");
            foreach (var item in file)
            {
                Console.WriteLine(item);
            }



            string[] subDir= Directory.GetDirectories(currentDirectory);

            Console.WriteLine($"-----SubDirs------");
            foreach (var item in subDir)
            {
                Console.WriteLine(item);   
            }

            string[] files = Directory.GetFiles(currentDirectory,"*.exe");
            Console.WriteLine($"-----Files------");
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }


            Directory.Delete(newDirectory);

            foreach (var item in Directory.GetDirectories(currentDirectory))
            {
                Console.WriteLine(item);
            }


            string root = Directory.GetDirectoryRoot(currentDirectory);
            Console.WriteLine($"-------Root");
            foreach (var item in Directory.GetDirectories(root))
            {
                //Console.WriteLine(item);
            }
            //Console.WriteLine(root);


            


            Console.ReadKey();
        }
    }
}
