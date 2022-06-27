
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ws_Agenda.Authetication;
using Ws_Agenda.DTOs;
using Ws_Agenda.Helpers;
using Ws_Agenda.Interfaces;
using Ws_Agenda.Models;

namespace Ws_Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController :ControllerBase
    {
        private readonly IUserInterface userInterface;
        

        public UserController(IUserInterface _userInterface)
        {
            userInterface = _userInterface;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Auth([FromBody]AuthenticateRequest model)
        {
            var respose = await userInterface.Auth(model);

            if(respose is null)
                return BadRequest(new { message = "User email or password is incorrect" });

            return Ok(respose);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var user = await userInterface.GetById(id);



            return Ok(user);    
        }
      
        [HttpPost("RegisterUser") ]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            var registed = await userInterface.AddUser(userCreateDto);
            if(registed is null)
                return BadRequest(new {message ="User already exist"});

            return StatusCode(201, new {message = "User created with exist" }); 
        }

        [HttpPut("UpdateUser")]

        public async Task<IActionResult>UpdateUser(UserDto userDto)
        {
            var update = await userInterface.UpdateUser(userDto);
            if (update is null)
                return BadRequest(new { message = "User is empyte" });

            return StatusCode(201, new { message = "User updated with exist" });
        }
    
       [HttpDelete("DeleteUser")]
       public async Task<IActionResult> DeleteUser(int id)
        {
            var userDelete = await userInterface.DeleteUser(id);
            if (userDelete is null)
                return BadRequest(new { message = "This user is already deleted" });

            return StatusCode(201, new { message = "User deleted with exist" });
        }

        [HttpPost("RestaurarUser")]
        public async Task<IActionResult>Restaurar(int id)
        {
            var userDelete = await userInterface.Restaurar(id);
            if (userDelete is null)
                return BadRequest(new { message = "This user is already Restaured" });

            return StatusCode(201, new { message = "User Restaured with exist" });
        }

        [HttpPut("ChangePasswordUser")]

        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var change = await userInterface.ChangePassword(passwordDto);
            if (change is null)
                return BadRequest(new { message = "User or old password is incorrect" });
            return StatusCode(201, new { message = "The Password was changed successful" });
        }  

        [HttpPut("RecoveryPassword")]

        public async Task<IActionResult>RecoveryPassword(RecoveryPasswordDto recovery)
        {
            var recoveryPassword = await userInterface.RecoveryPassword(recovery);
            if (recoveryPassword is null)
                return BadRequest(new { message = "Email incorrect" });
            return StatusCode(201, new { message = "We send email To your mail" });
        }

        [HttpPut("RecoveryPassword2")]

        public async Task<IActionResult> RecoveryPassword2(RecoveryPassword2Dto recovery2)
        {
            var recoveryPassword = await userInterface.RecoveryPassword2(recovery2);
            if (recoveryPassword is null)
                return BadRequest(new { message = "Email or user is incorret" });
            return StatusCode(201, new { message = "The Password was recovered successful" });
        }
    }


}
