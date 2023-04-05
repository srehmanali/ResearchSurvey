
using CoreDomain.Constants;
using CoreDomain.DataModels.Internal;
using CoreDomain.ResponseModels;
using CoreDomain.ViewModels.AuthModels;
using DataService.Context;
using DataService.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<Response> RegisterUserAsync(RegisterModel model)
        {
            var userEmailExists = await userManager.FindByEmailAsync(model.Email);

            if (userEmailExists != null)
                return new Response { Status = "Error", Message = "User already exist!", IsSuccess = false };

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                EmailConfirmed = false
            };

            //Create User
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again.", IsSuccess = false, Errors = result.Errors.Select(e => e.Description) };

            //Add user to a role "User"
            if (!await roleManager.RoleExistsAsync(Roles.Interviewer.ToString()))
                await roleManager.CreateAsync(new IdentityRole(Roles.Interviewer.ToString()));
            await userManager.AddToRoleAsync(user, Roles.Interviewer.ToString());

            return new Response { Status = "Success", Message = "User created successfully!", IsSuccess = true };
        }

        public async Task<Response> LoginUserAsync(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if(user == null)
                return new Response { Status = "Error", Message = "User not found", IsSuccess = false };

            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                ApplicationDbContext db = new ApplicationDbContext();
                
                return new Response
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Status = "Success",
                    IsSuccess = true
                };

            }
            return new Response { Status = "Error", Message = "User login failed! Please check user details and try again.", IsSuccess = false};
        }
    }
}
