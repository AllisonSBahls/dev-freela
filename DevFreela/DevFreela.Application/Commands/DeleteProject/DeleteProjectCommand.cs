using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
