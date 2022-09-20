using AutoMapper;
using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItemTypes
{
    public class GetWorkItemTypeById
    {
        public class Query : IRequest<QueryResult>
        {
            public Query(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class QueryResult
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = "";
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<WorkItemType, QueryResult>();
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
                var workItemType = await _context.WorkItemTypes.FindAsync(request.Id);

                return _mapper.Map<QueryResult>(workItemType);
            }
        }
    }
}
