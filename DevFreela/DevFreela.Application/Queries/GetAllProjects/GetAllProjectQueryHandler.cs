using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllProjectQueryHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _context.Projects;

            var projectViewModel = await projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToListAsync();
            
            return projectViewModel;
        }
    }
}
