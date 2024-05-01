using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI_Dotnet8.Entities
{
    public class Employee
    {
        //user
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  int Id { get; set; }
        [Required]
        public  string UserName { get; set; } = string.Empty;
        [Required]
        public  string FirstName { get; set; } = string.Empty;
        [Required]
        public  string LastName { get; set; } = string.Empty;
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string Phone { get; set; } = string.Empty;

        public Role Role { get; set; }
        public Permission Permission { get; set; }

    }
}
