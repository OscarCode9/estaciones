using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

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
            DatosEstaciones pruebas = new DatosEstaciones();
            

        }
        public double v1st1_;
        public double v1st2_;
        public double v2st2_;
        public double v3st2_;
        public double v1st3_;
        public double v2st3_;
        public double v3st3_;
        public double v4st3_;
        public double v1st4_;
        public double v2st4_;
        public double v3st4_;

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ThreadStart delegado = new ThreadStart(CorrerProceso);
           
            Thread hilo = new Thread(delegado);
 
            hilo.Start();
            ThreadStart delegado1= new ThreadStart(CorresProceso2);

            Thread hilo1 = new Thread(delegado1);

            hilo1.Start();

        }
        

        private void CambiarDatos()
        {
            Random random = new Random();
            this.v1st1_ = random.NextDouble(45.23, 45.80);
            this.v1st2_ = random.NextDouble(40.5, 40.539);
            this.v2st2_ = random.NextDouble(124.7, 124.780);
            this.v1st3_ = random.NextDouble(30.4, 30.8);
            this.v2st3_ = random.NextDouble(27.6, 27.9);
            this.v3st3_ = random.NextDouble(44.5, 40.69);
            this.v4st3_ = random.NextDouble(44.5, 40.7);
            this.v1st4_ = random.NextDouble(36.4, 36.6);
            this.v2st4_ = random.NextDouble(38.1, 38.2);
            this.v3st4_ = random.NextDouble(135.2, 135.6);
        }
        private void CorrerProceso()
        {
            while (true)
            {
                CambiarDatos();
                Thread.Sleep(1000);
            }
        }

        private void CorresProceso2()
        {
            while (true)
            {
                AgregarDatosTabla();
                Thread.Sleep(3000);
            }
        }

        

    private void AgregarDatosTabla()
        {
            Random r = new Random();
            int aleatorio = r.Next(0, 1000);

            
            Application.Current.Dispatcher.Invoke(new Action(() => {
                this.qr.Text = Convert.ToString(aleatorio);
            }));
            int okst1;
            int okst2;
            int okst3;
            int okst4;

            int ngst1;
            int ngst2;
            int ngst3;
            int ngst4;

            int gauNg;
            int gauOk;

            

            if(this.v1st1_ > 45.70+0.075 ||this.v1st1_ < 45.70 - 0.075)
            {
                CambiarEstadoBoton(1,1);
                okst1 = 0;
                ngst1 = 1;
            }
            else
            {
                ngst1 = 0;
                okst1 = 1;
                CambiarEstadoBoton(1, 0);
            }

            if(this.v1st2_ >= 40.5 && this.v1st2_ <= 40.5+0.039)
            {
                CambiarEstadoBoton(2, 0);
                okst2= 1;
                ngst2 = 0;
                
            }
            else
            {
                
                CambiarEstadoBoton(2, 1);
                ngst2 = 1;
                okst2 = 0;

            }

            if( this.v1st3_ > 30.5 + 0.2 || this.v1st3_ < 30.5 - 0.2)
            {
                CambiarEstadoBoton(3, 1);
                okst3 = 0;
                ngst3 = 1; 
                
                
            }
            else
            {
                CambiarEstadoBoton(3, 0);
                ngst3 = 0;
                okst3 = 1;

            }

            if( this.v1st4_ > 36.4 +  0.15 || this.v1st4_ < 36.4)
            {
                CambiarEstadoBoton(4, 1);
                okst4 = 0;
                ngst4 = 1;

            }
            else
            {
                CambiarEstadoBoton(4, 0);
                ngst4 = 0;
                okst4 = 1;

            }

            if (okst1 == 1 && okst2 == 1 && okst3 == 1 && okst4 == 1)
            {
                gauOk = 1;
                gauNg = 0;

                Application.Current.Dispatcher.Invoke(new Action(() => {
                    int num = Convert.ToInt32(this.ok.Text);
                    num = num + 1;
                    this.ok.Text = Convert.ToString(num);
                }));

                
            }else
            {
                gauOk = 0;
                gauNg = 1;

                Application.Current.Dispatcher.Invoke(new Action(() => {
                    int num = Convert.ToInt32(this.ng.Text);
                    num = num + 1;
                    this.ng.Text = Convert.ToString(num);
                }));

                
            }

            var data = new Test
            {
                date = "14/08/2017 13:42:49",
                code = "170814A0001",

                valorst1 = this.v1st1_,
                okst1 = okst1,
                ngst1 = ngst1,

                valorst2 = this.v1st2_,
                okst2 = okst2,
                ngst2 = ngst2,

                valorst3 = this.v1st3_,
                okst3 = okst3,
                ngst3 = ngst3,

                valorst4 = this.v1st4_,
                okst4 = okst4,
                ngst4 = ngst4,

                gauNg = gauNg,
                gauOk = gauOk,
                visNg = 0,
                visOk = 1

            };


            Application.Current.Dispatcher.Invoke(new Action(() => {
                DatosGrid.Items.Add(data);
                this.v1st1.Text = Convert.ToString(v1st1_);
                this.v1st2.Text = Convert.ToString(v1st2_);
                this.v2st2.Text = Convert.ToString(v2st2_);
                this.v1st3.Text = Convert.ToString(v1st3_);
                this.v2st3.Text = Convert.ToString(v2st3_);
                this.v3st3.Text = Convert.ToString(v3st3_);
                this.v4st3.Text = Convert.ToString(v4st3_);
                this.v1st4.Text = Convert.ToString(v1st4_);
                this.v2st4.Text = Convert.ToString(v2st4_);
                this.v3st4.Text = Convert.ToString(v3st4_);

            }));

           
            
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
            Application.Current.Dispatcher.Invoke(new Action(() => {

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

            }));

        }

        private void Cuando_haga_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Hola pinche putita");

        }

        private void Btn1(object sender, RoutedEventArgs e)
        {
            string qrTb1 = "98273498742";
            Random random = new Random();
            this.v1st1_ = random.NextDouble(45.23, 45.80);
            int okst1;

            if (this.v1st1_ > 45.70 + 0.075 || this.v1st1_ < 45.70 - 0.075)
            {
                CambiarEstadoBoton(1, 1);
                okst1 = 0;
               
            }else
            {
                okst1 = 1;
            }
            DatosEstaciones ComoYoQuieraWUeyNohayPedo = new DatosEstaciones();
            ComoYoQuieraWUeyNohayPedo.InsertTableOne(qrTb1, this.v1st1_,okst1);

        }

        private void Btn2(object sender, RoutedEventArgs e)
        {
            string qrTb1 = "98273498742";
            Random random = new Random();
            this.v1st2_ = random.NextDouble(45.23, 45.80);
            this.v2st2_ = random.NextDouble(45.23, 45.80);
            this.v3st2_ = random.NextDouble(45.23, 45.80);
            int okst1;
            if (((this.v1st2_ >= 124.7 && this.v1st2_ <= 124.7 + 0.075) && (this.v1st2_ >= 124.7 && this.v1st2_ <= 124.7)) && (this.v2st2_ >= 124.7 && this.v2st2_ <= 124.7 + 0.075))
            {
                CambiarEstadoBoton(1, 1);
                okst1 = 0;
            }
            else
            {
                okst1 = 1;
            }
            DatosEstaciones ComoYoQuieraWUeyNohayPedo = new DatosEstaciones();
            ComoYoQuieraWUeyNohayPedo.InsertEstacion2(qrTb1, this.v1st2_, this.v2st2_, this.v3st2_, okst1);




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
    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
