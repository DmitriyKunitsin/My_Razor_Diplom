using WebAppDiplomTST.Data.Identity;

namespace WebAppDiplomTST.Data.Tests
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
