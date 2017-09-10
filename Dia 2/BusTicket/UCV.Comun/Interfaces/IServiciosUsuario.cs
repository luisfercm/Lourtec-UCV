using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.Comun.Interfaces
{
  public  interface IServiciosUsuario
    {
        List<Usuario> GetUsuarios();
        void SaveUsuario(Usuario usuario);
        void SaveUsuario(List<Usuario> usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);

        Usuario Login(Usuario usuario);

    }
}
