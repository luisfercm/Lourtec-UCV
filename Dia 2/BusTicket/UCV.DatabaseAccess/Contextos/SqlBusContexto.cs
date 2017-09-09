using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCV.Comun.Modelos;

namespace UCV.DatabaseAccess.Contextos
{
    public class SqlBusContexto:DbContext
    {
        public DbSet<Compania> Companias { get; set; }
        public DbSet<Reserva> Reservas{ get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Viaje> Viajes { get; set; }


        public SqlBusContexto():base()
        {

        }
    }
}
