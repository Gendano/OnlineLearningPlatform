﻿namespace sacafoldinh1.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
       
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public int Score { get; set; }
        public List<Answer>? Answers { get; set; } = new List<Answer>();
    }
}