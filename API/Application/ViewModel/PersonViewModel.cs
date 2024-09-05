using System.ComponentModel.DataAnnotations;

namespace API.Application.ViewModel {
    public class PersonViewModel {
        public string Name { get; set; }
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
