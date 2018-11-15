using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkStatusService : AbstractLinkStatusService, ILinkStatusService
	{
		public LinkStatusService(
			ILogger<ILinkStatusRepository> logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusServerRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper bolLinkStatusMapper,
			IDALLinkStatusMapper dalLinkStatusMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base(logger,
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
    <Hash>7a1bdacbd5d04334917552649e00df84</Hash>
</Codenesium>*/