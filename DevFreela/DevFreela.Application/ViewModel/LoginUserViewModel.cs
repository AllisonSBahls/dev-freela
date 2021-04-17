using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.ViewModel
{
    public class LoginUserViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public LoginUserViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
