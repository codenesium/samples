using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class FeedRepository : AbstractFeedRepository, IFeedRepository
	{
		public FeedRepository(
			ILogger<FeedRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>770c062992e8697fb3c6e41641b0fac9</Hash>
</Codenesium>*/