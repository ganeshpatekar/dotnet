using System.ComponentModel.DataAnnotations;
namespace DotNetCoreMVCApp.Models
{
    public class Employee
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Range(15, 40, ErrorMessage = "Please enter valid age")]
        public int Age { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid, enter like # or #.##")]
        public decimal Salary { get; set; }


        public string Department { get; set; }

        [RegularExpression(@"^[MF]+$", ErrorMessage = "Select any one option")]
        public string Gender { get; set; }

    }
}
