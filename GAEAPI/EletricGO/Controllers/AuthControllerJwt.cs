using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using ElettricGO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using DDDSample1.Domain.Users;
using System.Text.Json;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private static List<User> UserList = new List<User>();
        private readonly AppSettings _applicationSettings;
        private readonly UserService _service;


        public AuthController(IOptions<AppSettings> _applicationSettings, UserService service)
        {
            this._applicationSettings = _applicationSettings.Value;


            this._service = service;

        }
        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()

        {

            return await _service.GetAllAsync();
        }

        [HttpGet("getUserRolebyEmail/{email}")]
        public async Task<ActionResult<string>> GetUserRolebyEmail(string email)
        {
            var r = await _service.GetUserRolebyEmail(email);

            if (r == null)
            {
                return NotFound();
            }

            return JsonSerializer.Serialize(r.role);;
        }

        // GET: api/Users/5
        [HttpGet("Users/active")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAtcive()
        {
            return await _service.GetAllActiveAsync();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Domain.Users.Login model)
        {
            var user = await _service.LoginUser(model);
            Console.WriteLine(user+"      f sdsd");
            if (user == null)
            {
                return BadRequest("invalid");
            }
            return Ok(JWTGenerator(user));
        }
        //JWTGenerator(user);

        public dynamic JWTGenerator(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);

            Console.WriteLine(user.Role+"        dsadsf           sdfsdf ");
             Console.WriteLine(user.Email+"        dsadsf           sdfsdf ");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Email), new Claim(ClaimTypes.Role, user.Role)
                       }), 
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
          
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encrypterToken = tokenHandler.WriteToken(token);

            HttpContext.Response.Cookies.Append("token", encrypterToken,
                 new CookieOptions
                 {
                     Expires = DateTime.Now.AddDays(7),
                     HttpOnly = true,
                     Secure = true,
                     IsEssential = true,
                     SameSite = SameSiteMode.None
                 });

            return new { token = encrypterToken , role = user.Role};
        }

        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {

           // Console.WriteLine("31231231231231231  "+credential);
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { this._applicationSettings.GoogleClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);
            //Console.WriteLine("31231231231231231  "+payload.Email);

            var user = await this._service.GetUserByEmail(payload.Email);
            Console.WriteLine(user+"      f sdsd");

            if(user != null){
                return Ok(JWTGenerator(user));
            }else{
                return BadRequest("Invalid."); 
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreatingUserDto model)
        {

            var ent = await _service.RegisterUser(model);

            return Ok(ent);
        }

         // Inactivate: api/Users/5
        [HttpPatch("Users/{email}")]
        public async Task<ActionResult<UserDto>> SoftDelete(string email)
        {
            var user = await _service.InactivateAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        // DELETE: api/Armazens/5
        [HttpDelete("Users/{email}/hard")]
        public async Task<ActionResult<UserDto>> HardDelete(string email)
        {
            try
            {
                var ent = await _service.DeleteAsync(email);

                if (ent == null)
                {
                    return NotFound();
                }

                return Ok(ent);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}
