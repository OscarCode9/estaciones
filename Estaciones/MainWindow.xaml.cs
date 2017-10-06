using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Estaciones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            qr.Text = "6879363";
           

        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            AgregarDatosTabla();


        }

        private void AgregarDatosTabla()
        {
            var data = new Test
            {
                date = "14/08/2017 13:42:49",
                code = "170814A0001",

                valorst1 = 45.774,
                okst1 = 1,
                ngst1 = 0,

                valorst2 = 40.540,
                okst2 = 1,
                ngst2 = 0,

                valorst3 = 64.58,
                okst3 = 0,
                ngst3 = 1,

                valorst4 = 67.6,
                okst4 = 0,
                ngst4 = 1,

                gauNg = 0,
                gauOk = 1,
                visNg = 0,
                visOk = 1
            };

            if(data.valorst1 > 45.70+0.075 || data.valorst1 < 45.70 - 0.075)
            {
                CambiarEstadoBoton(1,1);
            }
            else
            {
                CambiarEstadoBoton(1, 0);
            }

            if(data.valorst2 >= 40.5 && data.valorst2 <= 40.5+0.039)
            {
                CambiarEstadoBoton(2, 0);
            }else
            {
                CambiarEstadoBoton(2, 1);
            }


            DatosGrid.Items.Add(data);
            DatosGrid.Items.Add(data);
            DatosGrid.Items.Add(data);
            DatosGrid.Items.Add(data);
            DatosGrid.Items.Add(data);
            //DatosGrid.Items.Clear();
        }

        private void CambiarEstadoBoton(int stNumero, int verdeRojo)
        {
            string path;
            if (verdeRojo == 1)
            {
                path= @"C:\Users\Oscar Martinez\Documents\Visual Studio 2015\Projects\Estaciones\Estaciones\botonRojo.png";

            }
            else
            {
                path = @"C:\Users\Oscar Martinez\Documents\Visual Studio 2015\Projects\Estaciones\Estaciones\boton.png";

            }

            switch (stNumero)
            {
                case 1:
                    st1.Fill = new ImageBrush(new BitmapImage(
   new Uri(path, UriKind.Relative)));
                    break;
                case 2:
                    st2.Fill = new ImageBrush(new BitmapImage(
   new Uri(path, UriKind.Relative)));
                    break;
                case 3:
                    st3.Fill = new ImageBrush(new BitmapImage(
   new Uri(path, UriKind.Relative)));
                    break;
                case 4:
                    st4.Fill = new ImageBrush(new BitmapImage(
   new Uri(path, UriKind.Relative)));
                    break;
                case 5:
                    gaCheck.Fill = new ImageBrush(new BitmapImage(
   new Uri(path, UriKind.Relative)));
                    break;
                default:
                    break;
            }

        }
    }
    public class Test
    {
        public string date { get; set; }
        public string code { get; set; }
        public double valorst1 { get; set; }
        
        public int okst1 { get; set; }
        public int ngst1 { get; set; }
        public double valorst2 { get; set; }
        
        public int okst2 { get; set; }
        public int ngst2 { get; set; }
        public double valorst3 { get; set; }
       
        public int okst3 { get; set; }
        public int ngst3 { get; set; }
        public double valorst4 { get; set; }
      
        public int okst4 { get; set; }
        public int ngst4 { get; set; }
        public int gauOk { get; set; }
        public int gauNg { get; set; }
        public int visOk { get; set; }
        public int visNg { get; set; }
    }
}
