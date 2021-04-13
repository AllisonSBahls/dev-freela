using DevFreela.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>> 
    {
        public string Query { get; private set; }

        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }
    }
}
