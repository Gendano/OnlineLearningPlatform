namespace sacafoldinh1.Models
{
    public class Course
    {
      public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ICollection<Assignment>? Assignments{ get; set; }
        public ICollection<Exam>? Exams{ get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Module>? Modules { get; set; }
    }
}
