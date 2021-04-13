using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public GetUserQueryHandler(DevFreelaDbContext context)

        {
            _context = context;
        }
    
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id.Equals(request.Id));

            if (user == null) return null;

            var userViewModel = new UserViewModel(user.Name, user.Email);

            return userViewModel;
        }
    }
}
