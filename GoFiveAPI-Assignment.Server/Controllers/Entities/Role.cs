using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI_Dotnet8.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
