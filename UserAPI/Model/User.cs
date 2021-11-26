using System.ComponentModel.DataAnnotations;

namespace Model.UserAPI
{
    public class User
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(16,ErrorMessage ="{0} cannot exceeds {1} characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(16,ErrorMessage ="{0} cannot exceeds {1} characters")]
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}