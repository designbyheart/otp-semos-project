using APIDemo;
using APIDemo.Controllers;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Security.Principal;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public AccountController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAccountTypes")]
        public IEnumerable<Account> Get()
        {
            var accounts = new  List<Account>();
            accounts.Add(new Account(0, CardType.Visa, AccountType.Klasik, "Ovo je klasik paket", true));
            accounts.Add(new Account(0, CardType.Visa, AccountType.Klasik, "Ovo je prestiz paket", true));
            accounts.Add(new Account(0, CardType.Visa, AccountType.Klasik, "Ovo je fluo paket", true));
           return accounts;
        }
    }
}