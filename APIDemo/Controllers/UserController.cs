using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("CreateUser")]
        public User Get()
        {
            var dateString = "5/1/2000 0:0:0 AM";
            var dateObj = DateTime.Parse(dateString);
           
            Console.WriteLine(dateObj.ToString());
          
            var user = new User("John Doe", "some@email.com", dateObj);

            user.Account = new Account(1000, CardType.Dina, AccountType.Klasik);

            return user;
        }
    }
}
