using API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller {

        [HttpPost]
        public IActionResult Auth(string username, string password) {
            // Static Method, no need search in database.
            if (username == "admin" && password == "admin") {
                object token = TokenService.GenerateToken(new Domain.Model.EmployeeAggregate.Employee());
                return Ok(token);
            }

            return BadRequest("Username or password invalid");
        }
    }
}
