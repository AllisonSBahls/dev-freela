using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.ViewModel
{
    public class SkillViewModel
    {
        public int Id { get; private set; }
        public string Description { get; private set; }

        public SkillViewModel(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
