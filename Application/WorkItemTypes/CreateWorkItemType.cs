using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItemTypes
{
    public class CreateWorkItemType
    {
        public class Command : IRequest<CommandResponse>
        {
            public string Name { get; set; } = "";
        }

        public class CommandResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = "";
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Command, WorkItemType>();
                CreateMap<WorkItemType, CommandResponse>();
            }
        }

        public class Handler : IRequestHandler<Command, CommandResponse>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var workItemType = _mapper.Map<WorkItemType>(request);
                _context.WorkItemTypes.Add(workItemType);

                await _context.SaveChangesAsync();

                return _mapper.Map<CommandResponse>(workItemType);
            }
        }
    }
}
