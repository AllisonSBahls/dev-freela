using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(CreateProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void CreateComment(CreateCommentInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);


    }
}
