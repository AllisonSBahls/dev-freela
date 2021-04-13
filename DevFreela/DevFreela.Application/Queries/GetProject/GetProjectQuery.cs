using DevFreela.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
