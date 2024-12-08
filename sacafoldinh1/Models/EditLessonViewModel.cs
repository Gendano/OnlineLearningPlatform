namespace sacafoldinh1.Models
{
    public class EditLessonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public int ModuleId { get; set; }
        public IFormFile VideoFile { get; set; }
    }
}
