using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext context, IConfiguration configuration)

        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DBSqlServer");
        }
        public List<SkillViewModel> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
            /*
            var skill = _context.Skills;

            var skillViewModel = skill
                .Select(p => new SkillViewModel(p.Id, p.Description)).ToList();

            return skillViewModel;
            */
        }
    }
}
