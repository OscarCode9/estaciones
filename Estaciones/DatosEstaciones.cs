using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Estaciones
{
    class DatosEstaciones
    {
        public String conexion = "Data Source=192.168.100.20;Initial Catalog=5Estaciones;Persist Security Info=True;User ID=5Estaciones;Password=12345";
        public DatosEstaciones()
        {
            
            SqlConnection cnn = new SqlConnection(conexion);
            try
            {
                cnn.Open();
                MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            }
            catch (Exception)
            {
                MessageBox.Show("Esto no vale verga compa");
            }   
            cnn.Close();
            MessageBox.Show("Se cerró la conexión.");
        }
        public void InsertTableOne(string qr, double valor, int ok)
        {
            using (SqlConnection connection = new SqlConnection(this.conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Estacion1(QRest1,Medicion1,Fechareg1,OK1) VALUES (@qr, @valor,SYSDATETIME() , @ng_ok)";
                    command.Parameters.AddWithValue("@qr", qr);
                    command.Parameters.AddWithValue("@valor", valor);
                    command.Parameters.AddWithValue("@ng_ok", ok);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("No se puedo hacer este desmadre.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void InsertEstacion2(string qr, double valor,double valor2, double valor3, int ok)
        {
            using (SqlConnection connection = new SqlConnection(this.conexion))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Estacion2(QRest1,Medicion2,Medicion2_1,Medicion2_2,Fechareg1,OK1) VALUES (@qr, @valor,@valor1,@valor2,SYSDATETIME() , @ng_ok)";
                    command.Parameters.AddWithValue("@qr", qr);
                    command.Parameters.AddWithValue("@valor", valor);
                    command.Parameters.AddWithValue("@valor1", valor2);
                    command.Parameters.AddWithValue("@valor2", valor3);
                    command.Parameters.AddWithValue("@ng_ok", ok);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("No se puedo hacer este desmadre.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }

}
