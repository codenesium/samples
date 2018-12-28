using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkLogService : AbstractLinkLogService, ILinkLogService
	{
		public LinkLogService(
			ILogger<ILinkLogRepository> logger,
			IMediator mediator,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogServerRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       mediator,
			       linkLogRepository,
			       linkLogModelValidator,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2343573b85291639a69376a33b102bff</Hash>
</Codenesium>*/