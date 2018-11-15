using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkLogService : AbstractLinkLogService, ILinkLogService
	{
		public LinkLogService(
			ILogger<ILinkLogRepository> logger,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogServerRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       linkLogRepository,
			       linkLogModelValidator,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a9c060bcd412816ecacecaf532efa341</Hash>
</Codenesium>*/