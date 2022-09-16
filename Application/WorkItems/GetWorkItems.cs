using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItems
{
    public class GetWorkItems
    {
        public class Query : IRequest<IEnumerable<QueryResult>> { }

        public class QueryResult
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
                CreateMap<WorkItem, QueryResult>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.WorkItemType, opt => opt.MapFrom(src => src.WorkItemType.Name))
                    .ForMember(dest => dest.WorkItemState, opt => opt.MapFrom(src => src.WorkItemState.Name));
            }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<QueryResult>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IEnumerable<QueryResult>> Handle(Query request, CancellationToken cancellationToken)
            {
                var workItems = await _context.WorkItems
                    .Include(workItem => workItem.WorkItemType)
                    .Include(workItem => workItem.WorkItemState)
                    .ToListAsync();



                return _mapper.Map<IEnumerable<QueryResult>>(workItems);
            }
        }
    }
}
