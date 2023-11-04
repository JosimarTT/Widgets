using AutoMapper;
using Grpc.Core;
using MediatR;
using WidgetsBE.Application.Widgets.GetWidgets;
using GrpcWidgets = GrpcLibrary.Widgets;

namespace WidgetsBE.Api.Services;

public class WidgetsService : GrpcWidgets.WidgetsService.WidgetsServiceBase
{
    private readonly IMediator _mediator;

    public WidgetsService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
    }

    public override async Task<GrpcWidgets.GetWidgetsResponse> GetWidgets(GrpcWidgets.GetWidgetsRequest request,
        ServerCallContext context)
    {
        return await _mediator.Send(new GetWidgetsQuery(request), context.CancellationToken);
    }
}