using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkStatusService : AbstractLinkStatusService, ILinkStatusService
	{
		public LinkStatusService(
			ILogger<ILinkStatusRepository> logger,
			IMediator mediator,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusServerRequestModelValidator linkStatusModelValidator,
			IDALLinkStatusMapper dalLinkStatusMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       mediator,
			       linkStatusRepository,
			       linkStatusModelValidator,
			       dalLinkStatusMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40a7f004b1dfe7e6c93e898f0f9946df</Hash>
</Codenesium>*/