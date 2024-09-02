using API.Application.ViewModel;
using API.Domain.DTOs;
using API.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]

    // Sobre Log, importar a interface ILogger.
    // Injetar o ILogger no construtor.
    // Usar o ILogger.Log(LogLevel.Information, "Mensagem");
    // LogLevel.Information, LogLevel.Warning, LogLevel.Error, LogLevel.Critical


    // Sobre erros. 
    // Criar uma controller para tratamento (ThrowController)
    // Ignorar api (ApiIgnore = True)
    // Criar rota de tratamento de erro para ambiente de teste e produção.
    // Configurar o program.cs para indicar o tratamento de erro.
    // Caso seja produção, apontar para app.UseExceptionHandler("error");, senão app.UseExceptionHandler("error-local-development");




    public class EmployeeController : ControllerBase {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper) {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeview) {

            string filepath = Path.Combine("Storage", employeeview.Photo.FileName);
            using Stream fileStream = new FileStream(filepath, FileMode.Create);
            employeeview.Photo.CopyTo(fileStream);
            //fileStream.Dispose();

            Employee employee = new Employee(employeeview.Name, employeeview.Age, filepath);

            _employeeRepository.AddEmployee(employee);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("{ID}/download")]
        public IActionResult DownloadPhoto(int ID) {
            Employee employee = _employeeRepository.Get(ID);

            if (employee == null) {
                return NotFound();
            }

            if (employee.photo == null) {
                return NotFound("Num tem foto não.");
            }

            byte[] DataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(DataBytes, "image/png");
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity) {

            _logger.Log(LogLevel.Error, "Deu erro");
            _logger.LogInformation("Get Employees");

            //throw new Exception("Deu ruim (Erro teste!!)");
            //List<Employee> lstEmployees = _employeeRepository.Get(pageNumber, pageQuantity);
            List<EmployeeDTO> lstEmployees = _employeeRepository.Get();
            return Ok(lstEmployees);
        }

        [HttpGet]
        [Route("GetByID/{ID}")]
        public IActionResult GetByID(int ID) {

           Employee Employee = _employeeRepository.Get(ID);
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(Employee);
            return Ok(employeeDTO);
        }
    }
}
