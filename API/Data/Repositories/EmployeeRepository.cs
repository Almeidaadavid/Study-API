using API.Domain.DTOs;
using API.Domain.Model;

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

        public EmployeeDTO? Get(int id)
        {
            var a = _context.Employees.Find(id);
            EmployeeDTO b = new EmployeeDTO() {
                id = a!.id,
                NameEmployee = a.name,
                Photo = a.photo
            };
            return b;
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
