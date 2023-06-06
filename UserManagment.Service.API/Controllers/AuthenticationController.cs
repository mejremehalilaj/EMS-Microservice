using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagment.Service.API.Models;
using UserManagment.Service.API.Models.Authentication.SignUp;
using UserManagment.Service.Services;
using UserManagment.Service.Models;
using UserManagment.Service.API.Models.Authentication.Login;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace UserManagment.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityRole> roleManager,
                                        SignInManager<IdentityUser> signInManager,
                                        IEmailService emailService,
                                        IConfiguration configuration
                                        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register ([FromBody] RegisterUser registerUser,string role)
        {

            // Check if user exists
            var userExists = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User already exists!" });
            }

            // Create the user
            IdentityUser user = new IdentityUser
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
                TwoFactorEnabled=true,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                // If user creation fails, return appropriate error message
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = errorMessage });
            }

            // Check if the specified role exists
            if (await _roleManager.RoleExistsAsync(role))
            {
                // Add the role to the user
                await _userManager.AddToRoleAsync(user, role);

                //Add Token to verify the email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);


                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"User created & Email Sent to {user.Email} successfully" });
            }
            else
            {
                // If the specified role does not exist, return an error message
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This role does not exist!" });
            }

            ////Check if user exist
            //var userExist=await _userManager.FindByEmailAsync(registerUser.Email);
            //if (userExist!=null)
            //{
            //    return StatusCode(StatusCodes.Status403Forbidden,
            //        new Response { Status = "Error", Message = "User already exists!" });
            //}

            ////Add the user in the database
            //IdentityUser user = new()
            //{
            //    Email = registerUser.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = registerUser.UserName,
            //};

            //if(await _roleManager.RoleExistsAsync(role)) 
            //{
            //    var result = await _userManager.CreateAsync(user, registerUser.Password);

            //    if (!result.Succeeded)
            //    {
            //        return StatusCode(StatusCodes.Status500InternalServerError,
            //            new Response { Status = "Error", Message = "User failed to create" });
            //    }
            //    //Add role to the user

            //    await _userManager.AddToRoleAsync(user,role);

            //    return StatusCode(StatusCodes.Status200OK,
            //           new Response { Status = "Success", Message = "User created successfully" });

            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //            new Response { Status = "Error", Message = "This role does not exist!" });
            //}



        }


        //[HttpGet]
        //public IActionResult TestEmail()
        //{
        //    var message = new Message(new string[] {"mejremehalilaj99@gmail.com"}, "Test", "<h1>Testing!</h1>");

        //    _emailService.SendEmail(message);
        //    return StatusCode(StatusCodes.Status200OK,
        //            new Response { Status = "Success", Message="Email Sent Successfully!"});
        //}

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token,string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result=await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = "Email Verified Successfully!" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "User does not exist." });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            //Checking the user
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user.TwoFactorEnabled)
            {
                await _signInManager.SignOutAsync();
                await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
                var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                var message = new Message(new string[] { user.Email! }, "OTP COnfirmation", token);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Succes", Message = $"We have sent an OTP to your Email {user.Email}" });
            }

            if (user != null && await _userManager.CheckPasswordAsync(user,loginModel.Password)) 
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach(var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                

                var jwtToken=GetToken(authClaims);

                return Ok(new
                {
                    token=new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration=jwtToken.ValidTo
                });
            }

            return Unauthorized(); 
        }

        [HttpPost]
        [Route("login-2FA")]
        public async Task<IActionResult>LoginWith2FA(string code,string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);

            if (signIn.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }



                var jwtToken = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { Status = "Succes", Message = $"Invalid Code"});
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires:DateTime.Now.AddHours(3),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        
    }
}
