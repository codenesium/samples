using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class BadgeService : AbstractBadgeService, IBadgeService
	{
		public BadgeService(
			ILogger<IBadgeRepository> logger,
			IMediator mediator,
			IBadgeRepository badgeRepository,
			IApiBadgeServerRequestModelValidator badgeModelValidator,
			IBOLBadgeMapper bolBadgeMapper,
			IDALBadgeMapper dalBadgeMapper)
			: base(logger,
			       mediator,
			       badgeRepository,
			       badgeModelValidator,
			       bolBadgeMapper,
			       dalBadgeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6dfb5c901c522af4819247bc47641cd9</Hash>
</Codenesium>*/