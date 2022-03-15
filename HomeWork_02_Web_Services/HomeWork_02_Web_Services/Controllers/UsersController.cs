using HomeWork_02_Web_Services.Models;
using HomeWork_02_Web_Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_02_Web_Services.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IJwtManagerRepository _jWTManager;

		public UsersController(IJwtManagerRepository jWTManager)
		{
			this._jWTManager = jWTManager;
		}

		[HttpGet]
		public List<string> Get()
		{
			var users = new List<string>
		{
			"Satinder Singh",
			"Amit Sarna",
			"Davin Jon"
		};

			return users;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate(UserModel usersdata)
		{
			var token = _jWTManager.Authenticate(usersdata);

			if (token == null)
			{
				return NotFound("User not found");
			}

			return Ok(token);
		}
	}
}
