using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        int Create(CreateUserInputModel inputModel);
    }
}
