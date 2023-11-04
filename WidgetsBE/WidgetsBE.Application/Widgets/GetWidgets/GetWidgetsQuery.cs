using AutoMapper;
using Google.Protobuf.Collections;
using GrpcLibrary.Widgets;
using MediatR;
using WidgetsBE.Persistence.Repositories;

namespace WidgetsBE.Application.Widgets.GetWidgets;

public class GetWidgetsQuery : IRequest<GetWidgetsResponse>
{
    public GetWidgetsRequest Request { get; }

    public GetWidgetsQuery(GetWidgetsRequest request)
    {
        Request = request;
    }

    public class Handler : IRequestHandler<GetWidgetsQuery, GetWidgetsResponse>
    {
        private readonly IMapper _mapper;
        private readonly WidgetsRepository _widgetsRepository;

        public Handler(IMapper mapper, WidgetsRepository widgetsRepository)
        {
            _mapper = mapper;
            _widgetsRepository = widgetsRepository;
        }

        public async Task<GetWidgetsResponse> Handle(GetWidgetsQuery command, CancellationToken cancellationToken)
        {
            try
            {
                var response = new GetWidgetsResponse { IsSuccess = true };
                response.Widgets.Add(_mapper.Map<RepeatedField<Widget>>(await _widgetsRepository.GetWidgets()));

                return response;
            }
            catch (Exception e)
            {
                return new GetWidgetsResponse { IsSuccess = false, Error = e.Message };
            }
        }
    }
}