using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungKiemTraTracNghiem.BusinessLayer.Abstract;
using UngDungKiemTraTracNghiem.DataAccessLayer.Abstract;
using UngDungKiemTraTracNghiem.DataAccessLayer.ResponsesObject;
using UngDungKiemTraTracNghiem.DtoLayer.AddUser;

namespace UngDungKiemTraTracNghiem.BusinessLayer.Service
{
    public class UserService : IUserService
    {
        public readonly IUserDal _userDal;
        public UserService(IUserDal userDal) { _userDal = userDal; }
        public async Task<CustomResponseDto<string>> CreateUser(SignUp signUp)
        {
            return await _userDal.CreateUser(signUp);
        }

        public async Task<CustomResponseDto<string>> SignIn(SignIn signIn)
        {
            return await _userDal.SignIn(signIn);
        }
    }
}
