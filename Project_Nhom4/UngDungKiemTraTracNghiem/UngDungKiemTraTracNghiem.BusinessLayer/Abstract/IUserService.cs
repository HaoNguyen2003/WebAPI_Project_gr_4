using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungKiemTraTracNghiem.DataAccessLayer.ResponsesObject;
using UngDungKiemTraTracNghiem.DtoLayer.AddUser;

namespace UngDungKiemTraTracNghiem.BusinessLayer.Abstract
{
    public interface IUserService
    {
        public Task<CustomResponseDto<string>> CreateUser(SignUp signUp);
        public Task<CustomResponseDto<string>> SignIn(SignIn signIn);
    }
}
