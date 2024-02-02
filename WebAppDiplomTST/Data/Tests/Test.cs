using WebAppDiplomTST.Data.Identity;

namespace WebAppDiplomTST.Data.Tests
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<UserTest> UserTest { get; set; }
        public Course.Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
