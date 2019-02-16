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
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       mediator,
			       linkLogRepository,
			       linkLogModelValidator,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c757719a9306f5dc7a3b4fc9726ff1be</Hash>
</Codenesium>*/