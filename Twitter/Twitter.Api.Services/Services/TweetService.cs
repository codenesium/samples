using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class TweetService : AbstractTweetService, ITweetService
	{
		public TweetService(
			ILogger<ITweetRepository> logger,
			ITweetRepository tweetRepository,
			IApiTweetRequestModelValidator tweetModelValidator,
			IBOLTweetMapper boltweetMapper,
			IDALTweetMapper daltweetMapper,
			IBOLLikeMapper bolLikeMapper,
			IDALLikeMapper dalLikeMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper
			)
			: base(logger,
			       tweetRepository,
			       tweetModelValidator,
			       boltweetMapper,
			       daltweetMapper,
			       bolLikeMapper,
			       dalLikeMapper,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper,
			       bolRetweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>93a3dcffa1a8e643226eb43fd44daf16</Hash>
</Codenesium>*/