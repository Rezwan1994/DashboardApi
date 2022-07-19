using DashboardAPI.Getway;
using DashboardAPI.Model.BEL;
using DashboardAPI.Universal.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DashboardAPI.Controllers
{
    [ApiController]
    public class TokenController :  ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly DBHelper _dbHelper = new DBHelper();
        public TokenController(IConfiguration config)
        {
            _configuration = config;
       
        }

   
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Route("api/gettoken")]
        public async Task<IActionResult> Get(UserLoginModel login)
        {
            if (login.Username != null && login.Password != null)
            {
              LoginRegistrationDAO loginRegistrationDAO = new LoginRegistrationDAO();
                var result = loginRegistrationDAO.TryLogin(login.Username, login.Password);
                LoginResponseModel loginResponse = new LoginResponseModel();
                if (result == true)
                {
                    loginResponse.status = true;
                    loginResponse.message = "Login Success";
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        //Subject = new ClaimsIdentity(claims.ToArray()),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"],
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    LoginResponseModel response = new LoginResponseModel();
                    response.status = true;
                    response.message = "Authenticated User.";
                    response.token = tokenHandler.WriteToken(token);
                    return Ok(response);
                }
                else
                {
                    LoginResponseModel response = new LoginResponseModel();
                    response.status = false;
                    response.message = "Invalid credentials";
                    response.token = null;
                    return Ok(response);
             
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
