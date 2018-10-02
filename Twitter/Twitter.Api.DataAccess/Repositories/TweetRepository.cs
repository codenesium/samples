using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial class TweetRepository : AbstractTweetRepository, ITweetRepository
	{
		public TweetRepository(
			ILogger<TweetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10d86cd191d4ea3ca4d99078c386c4da</Hash>
</Codenesium>*/