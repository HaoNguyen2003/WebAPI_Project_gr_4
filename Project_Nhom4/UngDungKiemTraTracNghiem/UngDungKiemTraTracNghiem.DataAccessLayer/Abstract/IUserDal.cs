using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungKiemTraTracNghiem.DataAccessLayer.ResponsesObject;
using UngDungKiemTraTracNghiem.DtoLayer.AddUser;

namespace UngDungKiemTraTracNghiem.DataAccessLayer.Abstract
{
    public interface IUserDal
    {
        public Task<CustomResponseDto<string>> CreateUser(SignUp signUp);
        public Task<CustomResponseDto<string>> SignIn(SignIn signIn);
    }
}
