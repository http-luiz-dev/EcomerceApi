using Ecomerce.Domain.Auth;
using Ecommerce.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        public UsersController(EcommerceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
             await _context.users.AddAsync(new Domain.Auth.User
            {
                Name = "John Doe",
                Password = "password123",
                Salt = "password123",
                Email = "luiz@aslanet.com.br"
            });
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = await _context.users.ToListAsync();
            return Ok(users);
        }
    }
}
