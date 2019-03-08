using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class BadgesService : AbstractBadgesService, IBadgesService
	{
		public BadgesService(
			ILogger<IBadgesRepository> logger,
			IMediator mediator,
			IBadgesRepository badgesRepository,
			IApiBadgesServerRequestModelValidator badgesModelValidator,
			IDALBadgesMapper dalBadgesMapper)
			: base(logger,
			       mediator,
			       badgesRepository,
			       badgesModelValidator,
			       dalBadgesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>03ab40c6afe88e6ff14df023785141a6</Hash>
</Codenesium>*/