namespace sacafoldinh1.Models
{
    public class ExamCreateViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<QuestionCreateViewModel> Questions { get; set; } = new List<QuestionCreateViewModel>();

    }
}
public class QuestionCreateViewModel
{
    public string Text { get; set; }
    public int Score { get; set; }
    public List<AnswerCrateViewModel> Answers { get; set; } = new List<AnswerCrateViewModel>();
}
public class AnswerCrateViewModel
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}