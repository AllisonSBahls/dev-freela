using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.InputModel
{
    public class CreateUserInputViewModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
