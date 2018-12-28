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
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       mediator,
			       tweetRepository,
			       tweetModelValidator,
			       bolTweetMapper,
			       dalTweetMapper,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper,
			       bolRetweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d6278c8eecb197b1fabe16917d0eb54a</Hash>
</Codenesium>*/