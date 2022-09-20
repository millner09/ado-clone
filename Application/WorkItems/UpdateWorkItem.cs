using AutoMapper;
using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItems
{
    public class UpdateWorkItem
    {
        public class Command : IRequest<CommandResponse>
        {
            public Command(Guid id, CommandBody body)
            {
                Id = id;
                Body = body;
            }

            public Guid Id { get; set; }
            public CommandBody Body { get; set; }
        }

        public class CommandBody
        {
            public string Title { get; set; } = string.Empty;
        }

        public class CommandResponse
        {
            public Guid Id { get; set; }
            public string Title { get; set; } = string.Empty;
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CommandBody, WorkItem>();
                CreateMap<WorkItem, CommandResponse>();
            }
        }

        public class Handler : IRequestHandler<Command, CommandResponse?>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CommandResponse?> Handle(Command request, CancellationToken cancellationToken)
            {
                var workItem = await _context.WorkItems.FindAsync(request.Id);

                if (workItem is null)
                    return null;

                _mapper.Map(request.Body, workItem);
                await _context.SaveChangesAsync();

                return _mapper.Map<CommandResponse>(workItem);
            }
        }
    }
}
