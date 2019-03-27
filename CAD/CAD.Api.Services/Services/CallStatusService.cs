using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallStatusService : AbstractCallStatusService, ICallStatusService
	{
		public CallStatusService(
			ILogger<ICallStatusRepository> logger,
			IMediator mediator,
			ICallStatusRepository callStatusRepository,
			IApiCallStatusServerRequestModelValidator callStatusModelValidator,
			IDALCallStatusMapper dalCallStatusMapper,
			IDALCallMapper dalCallMapper)
			: base(logger,
			       mediator,
			       callStatusRepository,
			       callStatusModelValidator,
			       dalCallStatusMapper,
			       dalCallMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d26ad2fc7c7950ee504bfd69921c4b97</Hash>
</Codenesium>*/