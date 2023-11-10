using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo;
using System.Data;

namespace Controlador
{
    public class LoginController : AtributosLogin
    {
        public static bool Acceso_Controller()
        {
            return ModelLogin.Acceso(Username, txt2);
        }
    }

    public class AtributosLogin
    {
        public static string Username { get; set; }
        public static string txt2 { get; set; }
        public AtributosLogin() { }


        public DataTable nivelUsuario_Controller()
        {
            return ModelLogin.nivelUser(Username, txt2);
        }
    }
}
