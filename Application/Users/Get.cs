using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Users
{
    public class Get
    {
        public class Query : IRequest<AppUser>
        {
        }

        public class Handler : IRequestHandler<Query, AppUser>
        {
            private readonly DataContext _context;
            private readonly IMediator _mediator;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMediator mediator, IUserAccessor userAccessor)
            {
                _context = context;
                _mediator = mediator;
                _userAccessor = userAccessor;
            }

            public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var providerId = _userAccessor.GetUserName();
                if (string.IsNullOrEmpty(providerId))
                    throw new Exception("ProviderId cannot be null or empty");

                var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.AuthProviderId == providerId);

                if (user is null)
                    user = await _mediator.Send(new Create.Command(providerId));

                return user;
            }
        }
    }
}