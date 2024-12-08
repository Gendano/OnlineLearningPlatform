namespace sacafoldinh1.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
       
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Question>?Questions { get; set; } = new List<Question>();
        public ICollection<ExamResult>? ExamResults { get; set; }
    }
}