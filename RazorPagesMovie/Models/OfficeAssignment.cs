using ContosoUniversity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorId { get; set; }
        [StringLength(50)]
        [Display(Name = "Office location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
