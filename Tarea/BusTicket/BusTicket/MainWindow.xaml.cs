using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusTicket
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {


            InitializeComponent();

            //this.Visibility = Visibility.Hidden;



            MainPanel.Visibility = Visibility.Hidden;

            dtFechaIda.SelectedDate = DateTime.Now;
            dtFechaIda.FirstDayOfWeek = DayOfWeek.Monday;
            dtFechaVuelta.SelectedDate = DateTime.Now;
            dtFechaVuelta.FirstDayOfWeek = DayOfWeek.Monday;

            dtFechaIda.DisplayDateStart = DateTime.Now;
            dtFechaVuelta.DisplayDateStart = DateTime.Now;





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            MainPanel.Visibility = Visibility.Visible;
            LoadFile.Visibility = Visibility.Hidden;

            EF.Reserva objReserva = new EF.Reserva()
            {
                Destino = (EF.Localizacion)cboInicioServicio.SelectedItem,
                Salida = (EF.Localizacion)cboFinServicio.SelectedItem,
                Fecha = dtFechaIda.SelectedDate.Value
            };

            BuscarViaje(objReserva);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LimpiarData();

            if (string.IsNullOrEmpty(txtUrlFile.Text))
            {
                MessageBox.Show("Seleciona un archivo de estaciones, por favor!.");
                return;
            }


            var objMyjSon = new MyJson<LocalizacionEntity>();
            //var objMyjSon = new MyJson<RutasEntity>();
            var lstRutas = objMyjSon.DeserializarFromFile(txtUrlFile.Text);

            if (lstRutas.Count > 0)
            {

                EF.EFModelContainer context = new EF.EFModelContainer();

                foreach (var objRutas in lstRutas)
                {
               
                        context.Localizacion.Add(new EF.Localizacion()
                        {
                            Ciudad = objRutas.Ciudad,
                            Estado = objRutas.Estado,
                            Pais = objRutas.Pais,
                            Estacion = objRutas.Estacion

                        });


                        context.SaveChanges();



                    /*
                    var objLocalizacion =  context.Localizacion.Add(new EF.Localizacion()
                    {
                        Ciudad = objRutas.Estaciones.Ciudad,
                        Estado = objRutas.Estaciones.Estado,
                        Pais = objRutas.Estaciones.Pais,
                        Estacion = objRutas.Estaciones.Estacion

                    });

                    context.Entry(objLocalizacion).State = System.Data.Entity.EntityState.Added;
                   


                   var objContextRuta=   context.Rutas.Add(new EF.Rutas()
                    {
                        Chofer = objRutas.Chofer,
                        Compania = objRutas.Compania,
                        FechaFin = objRutas.FechaFin,
                        FechaInicio = objRutas.FechaInicio,
                        IdRuta = Guid.NewGuid() ,
                        Estaciones= objLocalizacion
                   });


                    context.Entry(objContextRuta).State = System.Data.Entity.EntityState.Added;

                    context.SaveChanges(); */

                }


                FillCbxEstaciones();


                this.MainPanel.Visibility = Visibility.Visible;
                this.LoadFile.Visibility = Visibility.Hidden;

            }
            else {
                MessageBox.Show("El archivo esta vacio, seleciona un archivo de estaciones, por favor!.");
            }



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //To get the location the assembly normally resides on disk or the install directory
            //   string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            //once you have the path you get the directory with:
            var directory = System.IO.Path.GetDirectoryName(path);


            OpenFileDialog OpenFileUrlDialog = new OpenFileDialog()
            {
                InitialDirectory = directory, //"c:\\",
                Filter = "Json files (*.json)|*.json|XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv",
                // FilterIndex = 2,
                RestoreDirectory = true
            };

            Nullable<bool> result = OpenFileUrlDialog.ShowDialog();
            if (result == true)
            {
                txtUrlFile.Text = OpenFileUrlDialog.FileName;
            }
        }

        private void dtFechaIda_KeyDown(object sender, KeyEventArgs e)
        {
            //dtFechaVuelta.SelectedDate = dtFechaIda.SelectedDate;
            //dtFechaVuelta.DisplayDateStart = dtFechaIda.SelectedDate;
        }

        private void dtFechaIda_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dtFechaVuelta.SelectedDate = dtFechaIda.SelectedDate;
            dtFechaVuelta.DisplayDateStart = dtFechaIda.SelectedDate;
        }

        private void rbTipoViaje_Ida_Checked(object sender, RoutedEventArgs e)
        {
            dtFechaVuelta.IsEnabled = false;
            dtFechaVuelta.SelectedDate = dtFechaIda.SelectedDate;
        }

        private void rbTipoViaje_Vuelta_Checked(object sender, RoutedEventArgs e)
        {
            dtFechaVuelta.IsEnabled = true;
        }

        public void FillCbxEstaciones() {



            EF.EFModelContainer context = new EF.EFModelContainer();

            var lstLocaciones = (List<EF.Localizacion>)context.Localizacion.ToList();
            List<LocalizacionEntity> lstLocalizacionEntity = new List<LocalizacionEntity>();

            foreach (var locacion in lstLocaciones)
            {
                var objLocalizacion = new LocalizacionEntity() { IdLocalizacion = locacion.IdLocalizacion, Ciudad = locacion.Ciudad, Estacion = locacion.Estacion, Estado = locacion.Estado, Pais = locacion.Pais };
                lstLocalizacionEntity.Add(objLocalizacion);
            }

            cboInicioServicio.ItemsSource = lstLocalizacionEntity;
            cboInicioServicio.SelectedItem = lstLocalizacionEntity.FirstOrDefault();

            cboFinServicio.ItemsSource = lstLocalizacionEntity;
            cboFinServicio.SelectedItem = lstLocalizacionEntity[1];

           
        }

        public void LimpiarData()
        {


            using (EF.EFModelContainer context = new EF.EFModelContainer())
            {
                var list = context.Rutas;
                foreach (EF.Rutas objRutas in list)
                    context.Rutas.Remove(objRutas);
                context.SaveChanges();
            }

            using (EF.EFModelContainer context = new EF.EFModelContainer())
            {
                var list = context.Localizacion;
                foreach (EF.Localizacion objLocalizacion in list)
                    context.Localizacion.Remove(objLocalizacion);
                context.SaveChanges();
            }


        }

        public void GenerarArchivos()
        {
            
           EF.EFModelContainer context = new EF.EFModelContainer();


            /*
                       var lstLocaciones = (List<EF.Localizacion>)context.Localizacion.ToList();
                       List<LocalizacionEntity> lstLocalizacionEntity = new List<LocalizacionEntity>();

                       foreach (var locacion in lstLocaciones)
                       {
                           var objLocalizacion = new LocalizacionEntity() { IdLocalizacion = locacion.IdLocalizacion, Ciudad = locacion.Ciudad, Estacion = locacion.Estacion, Estado = locacion.Estado, Pais = locacion.Pais };
                           lstLocalizacionEntity.Add(objLocalizacion);
                       }

                       var objMyjson = new MyJson<LocalizacionEntity>();
                       var json = objMyjson.ConverterJsonToString(lstLocalizacionEntity);
                       objMyjson.SaveFileJson("Localizaciones.json", json);

                        */

            var lstRutas = (List<EF.Rutas>)context.Rutas.ToList();

           List<RutasEntity> lstRutasentity = new List<RutasEntity>();

           foreach (var objRuta in lstRutas)
           {
               var objRutasEntity = new RutasEntity()
               {
                   //IdRuta = Guid.NewGuid(),
                   Chofer = objRuta.Chofer,
                   Compania = objRuta.Compania,
                   FechaFin = objRuta.FechaFin,
                   FechaInicio = objRuta.FechaInicio,
                   Estaciones = new LocalizacionEntity()
                   {
                       Ciudad = objRuta.Estaciones.Ciudad,
                       Estacion = objRuta.Estaciones.Estacion,
                       Estado = objRuta.Estaciones.Estado,
                       Pais = objRuta.Estaciones.Pais
                   }
               };
               lstRutasentity.Add(objRutasEntity);
           }


           var objMyjsonRutas = new MyJson<RutasEntity>();
           var jsonRutas = objMyjsonRutas.ConverterJsonToString(lstRutasentity);
           objMyjsonRutas.SaveFileJson("Rutas.json", jsonRutas); 

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            this.MainPanel.Visibility = Visibility.Visible;
            this.LoadFile.Visibility = Visibility.Hidden;

         

          

        }


        public void BuscarViaje(EF.Reserva reserva)
        {

            EF.EFModelContainer contexto = new EF.EFModelContainer();



            var query = contexto.Rutas.Where(obj => obj.Estaciones.Equals(reserva.Destino) && obj.Estaciones.Equals(reserva.Salida) && obj.FechaInicio >= reserva.Fecha).ToList();


            //LVResultados.ItemsSource = query;


            //var query = from q in Rutas
            //            where q.Estaciones.Contains(reserva.Destino) &&
            //            q.Estaciones.Contains(reserva.Salida) &&
            //            q.FechaInicio >= reserva.Fecha
            //            select q;

            //query = Rutas.Where(g => true).Select(g => g);
            //Resultados = query.ToList();
            //LVResultados.ItemsSource = Resultados;



        }


    }
}
 

[Serializable]
public class RutasEntity : ISerializable
{

   // public System.Guid IdRuta { get; set; }
    public string Chofer { get; set; }
    public string Compania { get; set; }
    public System.DateTime FechaInicio { get; set; }
    public System.DateTime FechaFin { get; set; }
    public LocalizacionEntity Estaciones { get; set; }

    public override string ToString()
    {
        return $"Ruta: {Chofer}-{Compania}--{FechaInicio}/{FechaFin}";
    }


    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      //  info.AddValue("IdRuta", IdRuta, typeof(System.Guid));
        info.AddValue("Chofer", Chofer, typeof(string));
        info.AddValue("Compania", Compania, typeof(string));
        info.AddValue("FechaInicio", FechaInicio, typeof(System.DateTime));
        info.AddValue("FechaFin", FechaFin, typeof(System.DateTime));
        info.AddValue("Estaciones", Estaciones, typeof(LocalizacionEntity));
    }
    public RutasEntity(SerializationInfo info, StreamingContext context)
    {
       // IdRuta = (Guid)info.GetValue("IdRuta", typeof(Guid));
        Chofer = (string)info.GetValue("Chofer", typeof(string));
        Compania = (string)info.GetValue("Compania", typeof(string));
        FechaInicio = (DateTime)info.GetValue("FechaInicio", typeof(DateTime));
        FechaFin = (DateTime)info.GetValue("FechaFin", typeof(DateTime));
        Estaciones = (LocalizacionEntity )info.GetValue("Estaciones", typeof(LocalizacionEntity));
    }
    public RutasEntity()
    {
    }

}



[Serializable]
public class LocalizacionEntity : ISerializable
{
 
    public int IdLocalizacion { get; set; }
    public string Estado { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }
    public string Estacion { get; set; }
 
    public override string ToString()
    {
        return $"{Estacion} - {Ciudad}, { Estado}, {Pais}";
    }

   
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("IdLocalizacion", IdLocalizacion, typeof(int));
        info.AddValue("Estado", Estado, typeof(string));
        info.AddValue("Ciudad", Ciudad, typeof(string));
        info.AddValue("Pais", Pais, typeof(string));
        info.AddValue("Estacion", Estacion, typeof(string));
    }
    public LocalizacionEntity(SerializationInfo info, StreamingContext context)
    {
        IdLocalizacion = (int)info.GetValue("IdLocalizacion", typeof(int));
        Estado = (string)info.GetValue("Estado", typeof(string));
        Ciudad = (string)info.GetValue("Ciudad", typeof(string));
        Pais = (string)info.GetValue("Pais", typeof(string));
        Estacion = (string)info.GetValue("Estacion", typeof(string));
    }
    public LocalizacionEntity()
    {
    }

}



public  class MyJson<T>
{
    public  string ConverterJsonToString(T obj) {        
        return JsonConvert.SerializeObject(obj);
    }


    public  string ConverterJsonToString(List<T> lstData)
    {
        return JsonConvert.SerializeObject(lstData);
    }

    public  void SaveFileJson(string filepath,string json)
    {

        FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine(json);
        }
        fs.Close();
    }


    public List<T> DeserializarFromFile(string FilePath)
    {
        FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
        string jsonStorage;
        using (StreamReader sr = new StreamReader(fs))
        {
            jsonStorage = sr.ReadToEnd();
        }

        return JsonConvert.DeserializeObject<List<T>>(jsonStorage);
    }


  

}


 