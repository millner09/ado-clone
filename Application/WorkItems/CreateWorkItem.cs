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
    public class CreateWorkItem
    {
        public class Command : IRequest<CommandResult>
        {
            public string Title { get; set; } = "";
            public Guid WorkItemType { get; set; }
            public Guid WorkItemState { get; set; }
        }


        public class CommandResult
        {
            public Guid Id { get; set; }
            public string Title { get; set; } = "";
            public string WorkItemType { get; set; } = "";
            public string WorkItemState { get; set; } = "";
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Command, WorkItem>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.WorkItemType, opt => opt.MapFrom(src => src.WorkItemType))
                    .ForMember(dest => dest.WorkItemState, opt => opt.MapFrom(src => src.WorkItemState));

                CreateMap<Command, WorkItemType>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WorkItemType));

                CreateMap<Command, WorkItemState>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WorkItemState));

                CreateMap<WorkItem, CommandResult>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.WorkItemType, opt => opt.MapFrom(src => src.WorkItemType.Name))
                    .ForMember(dest => dest.WorkItemState, opt => opt.MapFrom(src => src.WorkItemState.Name));
            }
        }

        public class Handler : IRequestHandler<Command, CommandResult>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CommandResult> Handle(Command command, CancellationToken cancellationToken)
            {
                var workItem = _mapper.Map<WorkItem>(command);
                _context.Add(workItem);
                await _context.SaveChangesAsync();

                return _mapper.Map<CommandResult>(workItem);
            }
        }
    }
}
