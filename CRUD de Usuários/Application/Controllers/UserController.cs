using CRUD_de_Usuários.Domain.Entidades;
using CRUD_de_Usuários.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_de_Usuários.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("ListUser")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            IEnumerable<User> user = await _userInterface.GetAlluser();
            if (user == null)
            {
                return NotFound("Não há usuários registrados!");
            }

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(User user)
        {
            IEnumerable<User> users = await _userInterface.CreateUser(user);
            return Ok(users);

        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<IEnumerable<User>>> UpdateUser(User user)
        {
            User registro = await _userInterface.GetUserById(user.Id);
            if (registro == null)
            {
                return NotFound("Registro não encontrado!");
            }
            IEnumerable<User> users = await _userInterface.UpdateUser(user);
            return Ok(user);

        }


        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<IEnumerable<User>>> DeleteUser(int userId)
        {
            User registro = await _userInterface.GetUserById(userId);
            if (registro == null)
            {
                return NotFound("Registro não encontrado!");
            }
            IEnumerable<User> users = await _userInterface.DeleteUser(userId);
            return Ok(userId);

        }

        [HttpGet("SearchUserId")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            User user = await _userInterface.GetUserById(userId);

            if (user == null)
            {
                return NotFound("Registro não encontrado!");
            }
            return Ok(user);
        }

        

    }
}
