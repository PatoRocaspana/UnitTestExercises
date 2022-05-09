namespace UnitTestExercises.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }

    public class RedirectResult : ActionResult { }
}
