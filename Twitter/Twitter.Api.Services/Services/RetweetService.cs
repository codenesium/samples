using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class RetweetService : AbstractRetweetService, IRetweetService
	{
		public RetweetService(
			ILogger<IRetweetRepository> logger,
			IMediator mediator,
			IRetweetRepository retweetRepository,
			IApiRetweetServerRequestModelValidator retweetModelValidator,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       mediator,
			       retweetRepository,
			       retweetModelValidator,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7ba94aa6c281ab0c2943a5baee379807</Hash>
</Codenesium>*/