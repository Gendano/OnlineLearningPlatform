namespace sacafoldinh1.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
