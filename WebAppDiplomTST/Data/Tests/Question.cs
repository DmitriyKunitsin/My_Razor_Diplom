using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAppDiplomTST.Data.Tests
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        [BindNever]
        public ICollection<Answer> Answers { get; set; }
    }
}
