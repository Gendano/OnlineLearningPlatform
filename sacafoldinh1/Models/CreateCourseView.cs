using System.ComponentModel.DataAnnotations;

namespace sacafoldinh1.Models
{
    public class CreateCourseView
    {
        [Required(ErrorMessage = "يرجى إدخال اسم الدورة")]
        public string Title { get; set; }

        [Required(ErrorMessage = "يرجى إدخال وصف الدورة")]
        public string Description { get; set; }

        [Required(ErrorMessage = "يرجى تحديد تاريخ البدء")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "يرجى تحديد تاريخ الانتهاء")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


    }
}
