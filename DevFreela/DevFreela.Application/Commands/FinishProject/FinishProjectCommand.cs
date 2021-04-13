using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public FinishProjectCommand(int id)
        {
            Id = id;
        }
    }
}
