using EntityFramework_RestaurantApi.Models;
using EntityFramework_RestaurantApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_RestaurantApi.Controllers
{
    // class responsible for managing user accounts
    [Route("api/account")]
    [ApiController] // all actions contained in this controller will go through the model validation process automatically
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;   
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto )
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
    }
}
