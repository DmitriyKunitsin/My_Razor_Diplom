using WebAppDiplomTST.Data.Tests;

namespace WebAppDiplomTST.Data.Course
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }//название курса

        public string Description { get; set; }//описание курса

        public ICollection<UserCourse> UserCourse { get; set; }
        public ICollection<Test> Tests { get; set; }

    }
}
