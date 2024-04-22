using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Model
{
    public class Panier {

        [Key]
        public int Id { get; set; }
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public IList<LignePanier> LPs { get; set; }
    }
}

