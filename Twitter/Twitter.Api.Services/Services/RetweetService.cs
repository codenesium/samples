using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class RetweetService : AbstractRetweetService, IRetweetService
	{
		public RetweetService(
			ILogger<IRetweetRepository> logger,
			IRetweetRepository retweetRepository,
			IApiRetweetServerRequestModelValidator retweetModelValidator,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       retweetRepository,
			       retweetModelValidator,
			       bolRetweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>15fc9135b60e4ff531ca597ad7e1de0a</Hash>
</Codenesium>*/