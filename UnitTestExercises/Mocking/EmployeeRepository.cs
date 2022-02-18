using System.Data.Entity;

namespace UnitTestExercises.Mocking
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db;

        public EmployeeRepository()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);

            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges() { }
    }

    public class Employee { }
}
