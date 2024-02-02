using WebAppDiplomTST.Data.Identity;
using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Data.Course
{
    public class UserCourse
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
