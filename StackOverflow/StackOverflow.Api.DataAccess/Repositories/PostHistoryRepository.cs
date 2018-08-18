using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>023164b64fefd7a5018f8758fd2d0fe8</Hash>
</Codenesium>*/