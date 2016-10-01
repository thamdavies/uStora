using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uStora.Model.Abstracts;

namespace uStora.Model.Models
{
    [Table("WishLists")]
    public class WishList : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public long ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}