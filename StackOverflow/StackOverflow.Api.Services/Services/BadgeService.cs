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
			IDALBadgeMapper dalBadgeMapper)
			: base(logger,
			       mediator,
			       badgeRepository,
			       badgeModelValidator,
			       dalBadgeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b77fcf77dc35cd1acd64cbadf2606e16</Hash>
</Codenesium>*/