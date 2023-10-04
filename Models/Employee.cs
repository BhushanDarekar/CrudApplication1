using System.ComponentModel.DataAnnotations;

namespace CrudApplication1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public decimal Salary { get; set; }
        //public required string sortDirection { get; set; }
    }
}


                                                                                   