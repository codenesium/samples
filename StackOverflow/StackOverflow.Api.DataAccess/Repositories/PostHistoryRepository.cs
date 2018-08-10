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
    <Hash>8df1097ab48ed77ecf0a449b6237cb28</Hash>
</Codenesium>*/