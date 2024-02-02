namespace WebAppDiplomTST.Data.Tests
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
