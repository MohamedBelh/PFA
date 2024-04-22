using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Reclamation
    {
        [Key]
        public int Id { get; set; }
        public String Description { get; set; }
        public String Libelle { get; set; }
        public Commande Commande { get; set; }

        [ForeignKey("Commande")]
        public int CommandeId { get; set; }
    }
}
