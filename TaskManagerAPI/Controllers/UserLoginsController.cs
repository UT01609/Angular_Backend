using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly TaskContext _context;

        public UserLoginsController(TaskContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(UserRegisterRequest request)
        {
            try
            {
                var user = new UserLogin()
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    role = request.Role
                };

                var data = await _context.UsersLogin.AddAsync(user);
                await _context.SaveChangesAsync();

                var res = new UserRegisterRequest
                {
                    FullName = data.Entity.FullName,
                    Email = data.Entity.Email,
                    Role = data.Entity.role
                };
                return Ok(res);



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(string Email, string password)
        {
            try
            {
                var user = _context.UsersLogin.FirstOrDefault(x => x.Email == Email);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (!isValid)
                {
                    throw new Exception("email or password not matched");
                }
                var res = new UserRegisterRequest
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.role
                };
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
