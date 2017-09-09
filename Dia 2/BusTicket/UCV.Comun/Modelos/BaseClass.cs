using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCV.Comun.Modelos
{
    public abstract class BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

    }
}
