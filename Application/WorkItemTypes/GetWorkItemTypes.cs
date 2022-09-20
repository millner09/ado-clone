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

namespace Application.WorkItemTypes
{
    public class GetWorkItemTypes
    {
        public class Query : IRequest<IEnumerable<QueryResponse>> { }

        public class QueryResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<WorkItemType, QueryResponse>();
        }

        public class Handler : IRequestHandler<Query, IEnumerable<QueryResponse>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<IEnumerable<QueryResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var workItemTypes = await _context.WorkItemTypes.ToListAsync();

                return _mapper.Map<IEnumerable<QueryResponse>>(workItemTypes);
            }
        }
    }
}
