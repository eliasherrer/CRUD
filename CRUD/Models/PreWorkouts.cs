using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class PreWorkouts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PreId { get; set; }
        public string? Description { get; set; }
        public string? flavor { get; set; }
    }
}
