using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;

        public UpdateProjectCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id.Equals(request.Id));

            project.Update(request.Title, request.Description, request.TotalCoast);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
