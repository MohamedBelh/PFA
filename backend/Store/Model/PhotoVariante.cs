using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class PhotoVariante
    {
        [Key]
        public int IdPhoto { get; set; }
        public String UrlImage { get; set; }
        public Variante Variante { get; set; }
        [ForeignKey("Variante")]
        public int VarianteId { get; set; }
    }
}
