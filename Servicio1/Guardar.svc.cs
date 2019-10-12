using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace Servicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Guardar" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Guardar.svc o Guardar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Guardar : IGuardar
    {

        public void guardar(int a, string b, string c, string d, int e, string f)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "insert into  Alumno1 values('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "')";
            cmd = new SqlCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string[] buscar(int cla)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            string[] datos = new string[6];
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "select * from Alumno1 where No_control=" + cla;
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            if (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetString(2);
                datos[3] = dato.GetString(3);
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetString(5);
            }
            con.Close();
            return datos;
        }

        public List<string> mostrar()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            var datos = new string[6];
            var consulta = new List<string>();
            con = new SqlConnection("Data Source=Sonia-pc;Initial Catalog=Alumnos;Integrated Security=false;user=lu;password=1");
            con.Open();
            cadena = "select * from Alumno1";
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            int i = 0;
            while (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetString(2);
                datos[3] = dato.GetString(3);
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetString(5);
                consulta.InsertRange(i, datos);
                i = i + 6;
            }
            con.Close();
            return consulta;
        }
        public string obtener(int con)
        {
            string caracteres = "123456789";
            StringBuilder res = new StringBuilder();

            Random rnd = new Random();
            while(0 < con --)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);

            }
            return res.ToString();
        }
        public string num(string n)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;
            try
            {
                nro = Convert.ToDouble(n);
            }
            catch
            {
                return "";

            }
            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales >0 )
            {
                dec = "CON" + decimales.ToString() + "/100";

            }
            res =toText(Convert.ToDouble(entero)) + dec;
            return res;
        }
        public string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "Cero";

            else if (value == 1) Num2Text = "Primero";
            else if (value == 2) Num2Text = "Segundo";
            else if (value == 3) Num2Text = "Tercero";
            else if (value == 4) Num2Text = "Cuarto";
            else if (value == 5) Num2Text = "Quinto";
            else if (value == 6) Num2Text = "Sexto";
            else if (value == 7) Num2Text = "Septimo";
            else if (value == 8) Num2Text = "Octavo";
            else if (value == 9) Num2Text = "Noveno";
            else if (value == 10) Num2Text = "Decimo";
            else if (value == 11) Num2Text = "Onceavo";
            else if (value == 12) Num2Text = "Doceavo";
            return Num2Text;   
        }
    

}

    }

