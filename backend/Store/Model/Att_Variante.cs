using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Att_Variante
    {
        [Key]
        public int Id { get; set; }
        public String cle { get; set; }
        public String Valeur { get; set; }
        public Variante Variante { get; set; }
        [ForeignKey("Variante")]
        public int VarianteId { get; set; }
    }
}
