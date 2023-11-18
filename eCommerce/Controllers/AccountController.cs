using eCommerce.DTOs;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration config;
        public AccountController(UserManager<ApplicationUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;

            config = configuration;
        }


        [HttpPost("register")]
        public async Task< IActionResult > Registration(RegisterDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser();
            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.Address = dto.Address;

            IdentityResult result =  await _userManager.CreateAsync(user, dto.Password);
             
            if(!result.Succeeded)
                return BadRequest(result.Errors.FirstOrDefault());
            
            
            return Ok("Account Add Success");               
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(dto.UserName);

            if(user is null)
                return Unauthorized();

            bool found = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!found)
                return Unauthorized();

            // claims token

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()));

            // get  roles

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role.ToString()));
            }


            // get Security Key

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

            SigningCredentials signingCred = new(
                    securityKey,
                    SecurityAlgorithms.HmacSha256
                );

            // Create token

            JwtSecurityToken myToken = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCred
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(myToken),
                expiration = myToken.ValidTo
            });
                
        }
    }
}
