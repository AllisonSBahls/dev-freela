using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> Comments { get; set; }

        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("PROJECTO 01", "DESCRIÇÃO PROJETO 01", 1, 1, 10000),
                new Project("PROJECTO 02", "DESCRIÇÃO PROJETO 02", 1, 1, 20000),
                new Project("PROJECTO 03", "DESCRIÇÃO PROJETO 03", 1, 1, 30000),
                new Project("PROJECTO 04", "DESCRIÇÃO PROJETO 04", 1, 1, 40000)
            };

            Users = new List<User>
            {
                new User("Usuário 01", "user01@fama-ro.com.br", new DateTime(1997, 02, 21)),
                new User("Usuário 02", "user02@fama-ro.com.br", new DateTime(1997, 02, 21)),
                new User("Usuário 03", "user03@fama-ro.com.br", new DateTime(1997, 02, 21))
            };

            Skills = new List<Skill>
            {
                new Skill("CSHARP"),
            new Skill("SQL")
            };
        }

    }
}
