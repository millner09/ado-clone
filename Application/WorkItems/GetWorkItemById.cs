using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItems
{
    public class GetWorkItemById
    {
        public class Query : IRequest<QueryResult> {
            public Query(Guid id) => Id = id;
            
            public Guid Id { get; set; }
        }


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

        public class Handler : IRequestHandler<Query, QueryResult>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<QueryResult> Handle(Query request, CancellationToken cancellationToken)
            {
                var workItems = await _context.WorkItems
                    .Include(x => x.WorkItemState)
                    .Include(x => x.WorkItemType)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return _mapper.Map<QueryResult>(workItems);
            }
        }
    }
}
