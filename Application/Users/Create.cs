using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Users
{
    public class Create
    {
        public class Command : IRequest<AppUser>
        {
            public Command(string providerId)
            {
                AuthProviderId = providerId;
            }
            public string AuthProviderId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, AppUser>
        {
            private readonly DataContext _context;

            public CommandHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<AppUser> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new AppUser();
                user.AuthProviderId = request.AuthProviderId;

                _context.Add(user);

                await _context.SaveChangesAsync();

                return user;
            }
        }
    }
}