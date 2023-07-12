using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET ...api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context) // DataContext is filled in via DependencyInjection
        {
            this.context = context;
        }

        //we use ActionResult and not IEnumerable as return type because so we can return http results
        // e.g. return BadRequest();
        // async code: in synchronous code the server is blocked until the request is returned
        //             in async code a new thread is started, when a request is still running
        //             the calling thread of a request will be notified if a request is done => await
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")] // e.g. .../api/users/2
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            // find works here with the primary key
            return await context.Users.FindAsync(id);
        }
    }
}