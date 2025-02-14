using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrediAPI.Models.Entities
{
    [Table("Titular")]
    public class Titular
    {
        public Titular()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TitularID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
    }

}
