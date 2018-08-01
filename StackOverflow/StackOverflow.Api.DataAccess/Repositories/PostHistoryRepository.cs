using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostHistoryRepository : AbstractPostHistoryRepository, IPostHistoryRepository
	{
		public PostHistoryRepository(
			ILogger<PostHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>53dccfb5f5bced79897f72f48eb9fdd2</Hash>
</Codenesium>*/