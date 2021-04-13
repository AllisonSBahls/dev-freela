using Dapper;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;
        
        public ProjectService(DevFreelaDbContext context, IConfiguration configuration)

        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DBSqlServer");
        }
        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _context.Projects;

            var projectViewModel = projects
                .Select(p => new ProjectViewModel(p.Id,p.Title, p.CreatedAt)).ToList();
            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _context.Projects
                .Include(c => c.Client)
                .Include(f => f.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCoast,
                project.CreatedAt,
                project.FinishedAt,
                project.Client.Name,
                project.Freelancer.Name
                );

            return projectDetailsViewModel;
        }

  

    }
}
