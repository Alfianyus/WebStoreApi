using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> listUsers = new List<UserDto>() {
            new UserDto()
            {
                FirstName="Bill",
                LastName="Gates",
                Email="bill@microsoft.com",
                Phone="08889988",
                Address="Indonesia"

            },

            new UserDto()
            {
                FirstName="Bob",
                LastName="Smith",
                Email="bob@microsoft.com",
                Phone="0880000",
                Address="Indonesia"

            }

        };

        [HttpGet]
        public IActionResult GetUsers() 
        {
            if(listUsers.Count > 0)
            {
                return Ok(listUsers);
            }

            return NoContent();
        
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if(id >= 0 && id < listUsers.Count)
            {
                return Ok(listUsers[id]);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            listUsers.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public  IActionResult UpdateUser(int id, UserDto user) 
        {
            if(id >= 0 && id < listUsers.Count) 
            {
                listUsers[id] = user;
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            if (id >= 0 && id < listUsers.Count)
            {
                listUsers.RemoveAt(id);
            }

            return NoContent();
        }

    }
}
