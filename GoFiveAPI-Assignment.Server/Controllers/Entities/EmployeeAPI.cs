namespace EmployeeAPI_Dotnet8.Entities
{
    public class Employee
    {
        //user
        public required int Id { get; set; }
        public required string UserName { get; set; } = string.Empty;
        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required string Phone { get; set; } = string.Empty;

        //role
        public required string Role { get; set;} = string.Empty;

        //permissions
        public bool? IsRead { get; set; }
        public bool? IsWrite { get; set;}
        public bool? IsDeleted { get; set;}
    }
}
