using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiApp.Models
{
    public class Division
    {
        [Key, Column(Order = 0), Required, RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH)]
        public string EventSku { get; set; }
        [ForeignKey(nameof(EventSku))]
        public virtual Event Event { get; set; }

        [Key, Column(Order = 1), Required]
        public string Name { get; set; }
    }
}
