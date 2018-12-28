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
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       mediator,
			       retweetRepository,
			       retweetModelValidator,
			       bolRetweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8e79c07c54b228fb1fa1628828dd171b</Hash>
</Codenesium>*/