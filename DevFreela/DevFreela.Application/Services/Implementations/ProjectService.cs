using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;

        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }
         public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _context.Projects;

            var projectViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();
            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCoast,
                project.CreatedAt,
                project.FinishedAt
                );

            return projectDetailsViewModel;
        }

        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelance, inputModel.TotalCoast);
            
            _context.Projects.Add(project);

            return project.Id;
        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(project.Title, project.Description, project.TotalCoast);

        }
        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _context.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Finished();
        }

       
        public void Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            project.Started();
        }


    }
}
