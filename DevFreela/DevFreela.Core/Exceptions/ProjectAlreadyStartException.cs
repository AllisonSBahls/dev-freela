using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadyStartException : Exception
    {
        public ProjectAlreadyStartException() : base("Project is already in start status")
        {

        }
    }
}
