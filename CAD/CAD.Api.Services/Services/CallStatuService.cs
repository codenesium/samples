using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallStatuService : AbstractCallStatuService, ICallStatuService
	{
		public CallStatuService(
			ILogger<ICallStatuRepository> logger,
			IMediator mediator,
			ICallStatuRepository callStatuRepository,
			IApiCallStatuServerRequestModelValidator callStatuModelValidator,
			IDALCallStatuMapper dalCallStatuMapper,
			IDALCallMapper dalCallMapper)
			: base(logger,
			       mediator,
			       callStatuRepository,
			       callStatuModelValidator,
			       dalCallStatuMapper,
			       dalCallMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aa8177053a8c52489d2d80af83933bd8</Hash>
</Codenesium>*/