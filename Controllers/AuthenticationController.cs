using ASP.NETFinalExamsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETFinalExamsProject.Controllers
{
    
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        } 
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            //Check If User Exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);    
            if(userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { StatusCode = "Error", Message = "User already exist!"});
            }


            //Add the User in the database
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            return result.Succeeded
                ? StatusCode(StatusCodes.Status201Created,
                    new Response { StatusCode = "Success", Message = "User Created Successfully!" })
                : StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { StatusCode = "Error", Message = "User Failed to Create!" });
            
            //Assign a role

        }


    }
}
