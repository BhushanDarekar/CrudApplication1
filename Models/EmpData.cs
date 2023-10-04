using System.ComponentModel.DataAnnotations;

namespace CrudApplication1.Models
{
    public class EmpData
    {
        [Required(ErrorMessage ="Field is required")]
        public string searchBy { get; set; }

        [Required(ErrorMessage ="Field is required")]
        public string searchString { get; set; }
    }
}
