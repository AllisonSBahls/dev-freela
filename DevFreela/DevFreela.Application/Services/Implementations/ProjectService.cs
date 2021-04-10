using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
         public List<ProjectViewModel> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDetailsViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(CreateProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }
        public void CreateComment(CreateCommentInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Finish(int id)
        {
            throw new NotImplementedException();
        }

       
        public void Start(int id)
        {
            throw new NotImplementedException();
        }


    }
}
