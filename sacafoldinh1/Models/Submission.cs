namespace sacafoldinh1.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment? Assignment { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime SubmissiomDate { get; set; }
        public int Grade { get; set; }
        public string Feedback { get; set; }
        public string FilePath { get; set; } // رابط ملف التسليم 

   }
}