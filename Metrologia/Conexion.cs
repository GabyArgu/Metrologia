using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Collections;

namespace Metrologia
{
    public abstract class Conexion
    {
		static string servidor = "localhost";
		static string database = "DB_Metrologia";
		static string usuario = "user";
		static string password = "administrador";
		static string puerto = "1433";

		private readonly string conexion = "Data Source="+servidor+","+puerto+";"+"user id="+usuario+";"+"password="+password+";"+"Initial Catalog="+database+";"+"Persist Security Info=true";


		protected SqlConnection establecerConexion() 
		{
			return new SqlConnection(conexion);
		}
		
    }
}
