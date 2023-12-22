using AutoMapper;
using MediatR;
using Ordering.Application.Common.Interfaces;

namespace Ordering.Application.Orders.Queries;

public class GetOrdersQuery : IRequest<List<OrderVm>>
{
    public string UserName { get; set; }

    public GetOrdersQuery(string userName)
    {
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
    }

}

public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderVm>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetOrdersListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<List<OrderVm>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
