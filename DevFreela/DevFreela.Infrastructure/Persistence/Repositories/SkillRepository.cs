using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DBSqlServer");
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT id, Description FROM Skills";

                var result = await sqlConnection.QueryAsync<SkillDTO>(script);

                return result.ToList();

                /*
                   var skill = _context.Skills;

                   var skillViewModel = skill
                       .Select(p => new SkillViewModel(p.Id, p.Description)).ToList();

                   return skillViewModel;
                 */
            }
        }
    }
}
