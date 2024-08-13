using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Brands
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandCountry { get; set; }

        public int PreId { get; set; }

        [ForeignKey("PreId")]
        public virtual PreWorkouts PreWorkouts { get; set; } //Nombre de la clase
    }
}
