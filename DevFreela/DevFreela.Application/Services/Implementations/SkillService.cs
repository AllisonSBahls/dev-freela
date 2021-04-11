using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;

        public SkillService(DevFreelaDbContext context)
        {
            _context = context;
        }
        public List<SkillViewModel> GetAll()
        {
            var skill = _context.Skills;

            var skillViewModel = skill
                .Select(p => new SkillViewModel(p.Id, p.Description)).ToList();

            return skillViewModel;
        }
    }
}
