using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>bb2f5642328460c7b0fe97ca683757b0</Hash>
</Codenesium>*/