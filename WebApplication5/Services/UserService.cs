using FluentValidation;
using System.ComponentModel;
using WebApplication5.Entity;
using WebApplication5.Repositories;
using WebApplication5.volidator;

namespace WebApplication5.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IValidator<User> _userValidator;

        public UserService(UserRepository userRepository, IValidator<User> userValidation)
        {
            _userRepository = userRepository;
            _userValidator = userValidation;
        }

        public async Task<User> CreateUser(User user)
        {

            var validationResult = await _userValidator.ValidateAsync(user);

            if (!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    Console.WriteLine(error);
                    return null;
                }
            }
            
            int insertedRow = await _userRepository.Create(user);

            if (insertedRow > 0)
            {
                return user;
            }

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error);
                return null;
            }
            int insertRow = await _userRepository.Update(user);
            if (insertRow > 0)
            {
                return user;
            }
            return null;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<string> DeleteById(int id)
        {
            var s = await _userRepository.GetById(id);
            if(s is null)
            {
                return "извените такого человека в списке нет";
            } else
            {
                await _userRepository.Delete(id);
                return "удаление прошло успешно";
            }
        }

        public async Task<List<User>> GetUserById(int id)
        {

            return await _userRepository.GetById(id);

        }


    }
}
