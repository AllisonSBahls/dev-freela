using Dapper;
using DevFreela.Application.ViewModel;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly string _connectionString;

        public GetAllSkillsQueryHandler(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DBSqlServer");
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT id, Description FROM Skills";

                var result = await sqlConnection.QueryAsync<SkillViewModel>(script);

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
