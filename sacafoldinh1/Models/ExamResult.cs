namespace sacafoldinh1.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int Score { get; set; }
        public int TotalScore { get; set; }
      
    }
}