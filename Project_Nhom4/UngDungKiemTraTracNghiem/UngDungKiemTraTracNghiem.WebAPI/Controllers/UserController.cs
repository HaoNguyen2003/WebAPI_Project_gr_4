using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UngDungKiemTraTracNghiem.BusinessLayer.Abstract;
using UngDungKiemTraTracNghiem.BusinessLayer.Service;
using UngDungKiemTraTracNghiem.DtoLayer.AddUser;

namespace UngDungKiemTraTracNghiem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService) { 
            _userService = userService;
        }


        [HttpPost("signUp")]
        public async Task<IActionResult> SignUpAsync(SignUp signUp)
        {
            var result= await _userService.CreateUser(signUp);
            return Ok(result);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignInAsync(SignIn signIn)
        {
            var result = await _userService.SignIn(signIn);
            return Ok(result);
        }
    }
}
