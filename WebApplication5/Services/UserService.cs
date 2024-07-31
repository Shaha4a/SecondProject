using System.ComponentModel;
using WebApplication5.Entity;
using WebApplication5.Repositories;

namespace WebApplication5.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            //TODO Validation
           int insertedRow = await _userRepository.Create(user);

            if (insertedRow > 0)
            {
                return user;
            }

            return null;
        }
        public async Task<User> UpdateUser(User user)
        {
            int insertRow = await _userRepository.Update(user);
            if (insertRow > 0)
            {
                return user;
            }
            return null;
        }
        public async Task<List<User>> GetAll()
        {
        //    List<User> list = new List<User>();

        //    if (list != null)
        //    {
        //        return _userRepository.GetAll();
        //    }
        //    else
        //    {
        //        return null;
        //    }
            return _userRepository.GetAll();
        }
        public async Task<bool> DeleteById(int id)
        {
            var s = _userRepository.GetById(id);
            if(s is null)
            {
                return false;
            } else
            {
                _userRepository.Delete(id);
                return true;
            }
        }
        public async Task<List<User>> GetUserById(int id)
        {
            //if(_userRepository.GetById(id) != null)
            //{
                
            //}
            return _userRepository.GetById(id);

        }
        

    }
}
