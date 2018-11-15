using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class TweetService : AbstractTweetService, ITweetService
	{
		public TweetService(
			ILogger<ITweetRepository> logger,
			ITweetRepository tweetRepository,
			IApiTweetServerRequestModelValidator tweetModelValidator,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
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
    <Hash>d8897fd8fff061cb7602bef95cef6ce3</Hash>
</Codenesium>*/