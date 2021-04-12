using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;

        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();


            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id.Equals(id));

            if (user == null) return null;

            var userViewModel = new UserViewModel(user.Name, user.Email);

            return userViewModel;
        }
    }
}
