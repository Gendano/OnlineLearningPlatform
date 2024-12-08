namespace sacafoldinh1.Models
{
    public class Enrollment
    {
       
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Progress { get; set; }
    }
}
