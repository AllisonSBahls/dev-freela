using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.InputModel
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelance { get; set; }
        public decimal TotalCoast { get; set; }

    }
}
