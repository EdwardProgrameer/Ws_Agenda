
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ws_Agenda.Authetication;
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
        public async Task<IActionResult> authenticate([FromBody]AuthenticateRequest model)
        {
            var respose = await userInterface.Auth(model);

            if(respose is null)
                return BadRequest(new { message = "User email or password is incorrect" });

            return Ok(respose);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var user = await userInterface.GetById(id);

            return Ok(user);    
        }
    
    }


}
