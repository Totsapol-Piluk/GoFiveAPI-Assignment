using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI_Dotnet8.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        public bool? IsRead { get; set; }

        public bool? IsWrite { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
