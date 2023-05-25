using System;
using Microsoft.AspNetCore.Mvc;
using user_api.DTO;
using user_api.Models;
using user_api.Repository.Interfaces;
using user_api.Utils;

namespace user_api.Controllers
{
	[ApiController]
    [Route("v1/[controller]")]
	public class UserController:ControllerBase
	{
		private readonly IUserRepository userRepository;

		public UserController(IUserRepository repository)
		{
			userRepository = repository;
		}

		[HttpPost("Register",Name = "Register")]
		public ActionResult Register([FromBody] UserDTO userDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			User user = new User();


			user.Age = userDto.Age;
            user.Email = userDto.Email;
            user.Name = userDto.Name;
            user.Username = userDto.Username;

            Password password = new Password();
			user.Password = password.Cryptograph(userDto.Password);

			userRepository.Register(user);

			return Ok(user);
		}

		[HttpDelete("Unregister",Name ="Unregister")]
		public ActionResult Unregister([FromBody] UserDTO user )
		{
            Password password = new Password();
            string pass = password.Cryptograph(user.Password);
			string hashedPass = "";
			if(pass != hashedPass)
			{
				return BadRequest("Bad!");
			}

			return Ok();
		}
	}
}

