using EmployeeAPI_Dotnet8.Entities;
using Microsoft.EntityFrameworkCore;


namespace EmployeeAPI_Dotnet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}