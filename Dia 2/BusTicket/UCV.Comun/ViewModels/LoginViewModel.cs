using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Interfaces;
using UCV.Comun.Modelos;

namespace UCV.Comun.ViewModels
{
    public class LoginViewModel
    {
        public Usuario Usuario { get; set; }
        private IServiciosUsuario ServiciosUsuarios { get; set; }

 

        public Usuario Login(string usuario, string password) {
            return new Usuario();
        }

        public Usuario Login()
        {
            var u = new Usuario()
            {
                UserName = Usuario.UserName,
                Password = Usuario.Password
            };

            Usuario.UserName = "Logged";
            Usuario.Password = "Logged";
         

            return u;
        }




    }
}
