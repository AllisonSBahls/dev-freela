using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _context;
        public DeleteProjectCommandHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id.Equals(request.Id));
            project.Cancel();
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
