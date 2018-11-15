using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class BadgeService : AbstractBadgeService, IBadgeService
	{
		public BadgeService(
			ILogger<IBadgeRepository> logger,
			IBadgeRepository badgeRepository,
			IApiBadgeServerRequestModelValidator badgeModelValidator,
			IBOLBadgeMapper bolBadgeMapper,
			IDALBadgeMapper dalBadgeMapper)
			: base(logger,
			       badgeRepository,
			       badgeModelValidator,
			       bolBadgeMapper,
			       dalBadgeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>43af2f66bc4ea5c98cdb97227812d53c</Hash>
</Codenesium>*/