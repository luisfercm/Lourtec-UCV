//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusTicket.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Localizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localizacion()
        {
            this.Estaciones = new HashSet<Rutas>();
        }
    
        public int IdLocalizacion { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estacion { get; set; }
    
        public virtual Reserva Destino { get; set; }
        public virtual Reserva Salida { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rutas> Estaciones { get; set; }
    }
}
