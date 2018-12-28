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
			IBOLLinkStatusMapper bolLinkStatusMapper,
			IDALLinkStatusMapper dalLinkStatusMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
			       mediator,
			       linkStatusRepository,
			       linkStatusModelValidator,
			       bolLinkStatusMapper,
			       dalLinkStatusMapper,
			       bolLinkMapper,
			       dalLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>23780c391fbca75fe9343301d2f8a56a</Hash>
</Codenesium>*/