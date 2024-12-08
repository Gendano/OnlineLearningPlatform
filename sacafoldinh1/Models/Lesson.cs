namespace sacafoldinh1.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? VideoPath { get; set; }
        public int ModuleId { get; set; }
        public Module? Module { get; set; }
      

    }
}
