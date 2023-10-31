using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modelo
{
    public class Conexion
    {
        public static SqlConnection getConnect()
        {
            SqlConnection connect;
            string server = "localhost";
            string database = "DB_Metrologia";
            string user = "user";
            string password = "administrador";
            string puerto = "1433";
            try
            {
                connect = new SqlConnection("Data Source=" + server + "," + puerto + ";" + "user id=" + user + ";" + "password=" + password + ";" + "Initial Catalog=" + database + ";" + "Persist Security Info=true");
                connect.Open();
                return connect;
            }
            catch (Exception)
            {
                return connect = null;
            }
        }
    }
}
