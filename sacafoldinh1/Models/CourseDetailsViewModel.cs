namespace sacafoldinh1.Models
{
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public List<ModuleViewModel> Modules { get; set; }
        public List<ExamViewModel> Exams { get; set; }
        public List<AssignmentViewModel> Assignments { get; set; }

        public class ModuleViewModel
        {

            public int ModuleId { get; set; }
            public string ModuleTitle { get; set; }
            public List<LessonViewModel> Lessons { get; set; }
        }

        public class LessonViewModel
        {
            public int LessonId { get; set; }
            public string LessonTitle { get; set; }

        }
        public class ExamViewModel
        {
            public int ExamId { get; set; }
            public string ExamTitle { get; set; }

        }
        public class AssignmentViewModel
        {
            public int AssignmentId { get; set; }
            public string AssignmentTitle { get; set; }
        }

    }
}
