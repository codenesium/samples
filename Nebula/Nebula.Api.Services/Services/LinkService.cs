using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class LinkService : AbstractLinkService, ILinkService
	{
		public LinkService(
			ILogger<ILinkRepository> logger,
			ILinkRepository linkRepository,
			IApiLinkServerRequestModelValidator linkModelValidator,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base(logger,
			       linkRepository,
			       linkModelValidator,
			       bolLinkMapper,
			       dalLinkMapper,
			       bolLinkLogMapper,
			       dalLinkLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>771aeb11e7acd2c2aa270cb1bbc9590a</Hash>
</Codenesium>*/