using System.ComponentModel.DataAnnotations;

namespace sacafoldinh1.Models
{
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? ProfilePicturePath { get; set; }
    }
}
