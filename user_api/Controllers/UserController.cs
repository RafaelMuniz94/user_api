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
		public ActionResult Register([FromBody] CreateUserDTO userDto)
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

		[HttpGet("{id}",Name ="findByID")]
		public async Task<ActionResult> FindByID(Guid id)
		{
                User user = await userRepository.FindByID(id);

                if (user == null)
                {
                    return NotFound("User ID not found!");
                }

                return Ok(user);

		}

        [HttpGet("/find", Name = "findByLogin")]
        public async Task<ActionResult> FindByLogin([FromQuery]FindDTO findDto)
        {
            User user = null;

            if (!string.IsNullOrEmpty(findDto.Username))
            {
                user = await userRepository.FindByLogin(findDto.Username);
            }
            else
            {
                user = await userRepository.FindByEmail(findDto.Email);
            }

            if (user == null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);

        }



        [HttpDelete("Unregister",Name ="Unregister")]
		public async Task<ActionResult> Unregister([FromBody] DeleteUserDTO userDto )
		{
            Password password = new Password();
            User user = await userRepository.FindByID(userDto.ID);

            if (user == null)
            {
                return NotFound("User ID not found!");
            }

            string pass = password.Cryptograph(userDto.Password);

			if(pass != user.Password)
			{
				return BadRequest("You must provide the right password!");
			}

			bool userRemoved = await userRepository.Delete(user);

			if (!userRemoved)
				return BadRequest("User cant be deleted!");

			return StatusCode(202);
		}
	}
}

