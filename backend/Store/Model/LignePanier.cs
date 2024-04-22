using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class LignePanier
    {
        [Key]
        public int IdLignePanier { get; set; }
        public int Quantite { get; set; }
        public Panier Panier { get; set; }
        [ForeignKey("Panier")]
        public int PanierId { get; set; }
        public Variante Variante { get; set; }
        public int VarianteId { get; set; }
    }
}
