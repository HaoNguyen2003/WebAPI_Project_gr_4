using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UngDungKiemTraTracNghiem.DataAccessLayer.Abstract;
using UngDungKiemTraTracNghiem.DataAccessLayer.ResponsesObject;
using UngDungKiemTraTracNghiem.DtoLayer.AddUser;
using UngDungKiemTraTracNghiem.EntityLayer.Data;
using UngDungKiemTraTracNghiem.EntityLayer.Model;

namespace UngDungKiemTraTracNghiem.DataAccessLayer.EFFramework
{
    public class UserDal : IUserDal
    {
        public readonly UserManager<User> _UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserDal(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _UserManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CustomResponseDto<string>> CreateUser(SignUp signUp)
        {
            if (signUp.Password != signUp.ConfirmPassWord)
            {
                Console.WriteLine("Error: Password and Confirm Password do not match.");
                return CustomResponseDto<string>.Fail(400, "Password and Confirm Password do not match");
            }
            var User = new User
            {
                Email = signUp.Email,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                UserName = signUp.Email,
                Avatar= "Image/Avatar/user.png"
            };
            var result = await _UserManager.CreateAsync(User, signUp.Password);
            if (!result.Succeeded)
            {
                List<string>listErrors=new List<string>();
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error.Description}");
                    listErrors.Add(error.Description);
                }
                return CustomResponseDto<string>.Fail(400, listErrors);
            }
            if (!await _roleManager.RoleExistsAsync(UserRole.teacher))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.teacher));
            }
            await _UserManager.AddToRoleAsync(User, UserRole.teacher);
            return CustomResponseDto<string>.Success(200,"Create finish Success");
        }

        public async Task<CustomResponseDto<string>> SignIn(SignIn signIn)
        {
            var User = await _UserManager.FindByEmailAsync(signIn.Email);
            if (User == null)
            {
                return CustomResponseDto<string>.Fail(400, "Email Invalid");
            }
            var PassWordValid = await _UserManager.CheckPasswordAsync(User, signIn.Password);
            if (!PassWordValid)
            {
                return CustomResponseDto<string>.Fail(400, "Password is wrong");
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, signIn.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var UserRole = await _UserManager.GetRolesAsync(User);
            foreach (var role in UserRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var secret = "TingHowLearningAPIASPANDQWERTYUIOPLKJHGASDFCVMIIGZAqeq19270878193742hsgysagdyepplmbnvxxeeejklanZXCVBNMx";
            var key = Encoding.UTF8.GetBytes(secret);
            var securityKey = new SymmetricSecurityKey(key);
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7005",
                audience: "User",
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
            );
            return CustomResponseDto<string>.Success(200,new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
