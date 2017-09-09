using System.ComponentModel.DataAnnotations.Schema;

namespace UCV.Comun.Modelos
{
    [Table("COMPANIA")]
    public class Compania: BaseClass
    {
        [Column("RUC",Order =1)]
        public string Ruc { get; set; }

        [Column("CALIFICACION", Order = 2)]
        public float Calificacion { get; set; }

    }
}