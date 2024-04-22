using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Paiement
    {

        [Key]
        public int IdPaiement { get; set; }
        public DateTime DatePaimenet { get; set; }
        public double Montant { get; set; }
        public string modePaiement { get; set; }

        public Commande commande { get; set; }
        [ForeignKey("Commande")]
        public int CommandeId { get; set; }

    }
}
