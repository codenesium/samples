using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class TweetService : AbstractTweetService, ITweetService
	{
		public TweetService(
			ILogger<ITweetRepository> logger,
			IMediator mediator,
			ITweetRepository tweetRepository,
			IApiTweetServerRequestModelValidator tweetModelValidator,
			IDALTweetMapper dalTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       mediator,
			       tweetRepository,
			       tweetModelValidator,
			       dalTweetMapper,
			       dalQuoteTweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>11626f4ef6360613de730d6ae8f4a6c0</Hash>
</Codenesium>*/