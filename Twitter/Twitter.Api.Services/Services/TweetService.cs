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
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base(logger,
			       tweetRepository,
			       tweetModelValidator,
			       boltweetMapper,
			       daltweetMapper,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper,
			       bolRetweetMapper,
			       dalRetweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ef5c1e93b5300ce3b0c703c48c787ddd</Hash>
</Codenesium>*/