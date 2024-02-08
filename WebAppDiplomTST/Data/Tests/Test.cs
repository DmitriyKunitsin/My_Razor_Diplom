using System.ComponentModel.DataAnnotations;
using WebAppDiplomTST.Data.Identity;

namespace WebAppDiplomTST.Data.Tests
{
    public class Test
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно для ввода")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле обязательно для ввода")]
        public string Title { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<UserTest>? UserTest { get; set; }
        public Course.Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
