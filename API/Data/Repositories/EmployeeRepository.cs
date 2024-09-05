using API.Domain.DTOs;
using API.Domain.Model.EmployeeAggregate;

namespace API.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context;
        public EmployeeRepository(ConnectionContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get()
        {
            List<EmployeeDTO> lstEmployees = _context.Employees.Select(p => new EmployeeDTO() {
                id = p.id,
                NameEmployee = p.name,
                Photo = p.photo
            }).ToList();
            return lstEmployees;
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            List<EmployeeDTO> lstEmployees = _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).Select(x => new EmployeeDTO() {
                id = x.id,
                NameEmployee = x.name,
                Photo = x.photo
            }).ToList();

            return lstEmployees;
        }
    }
}
