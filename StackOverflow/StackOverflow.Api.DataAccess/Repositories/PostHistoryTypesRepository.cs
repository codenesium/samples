using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostHistoryTypesRepository : AbstractPostHistoryTypesRepository, IPostHistoryTypesRepository
	{
		public PostHistoryTypesRepository(
			ILogger<PostHistoryTypesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9e53b1cdf92c7bf438ae4a7e83e3e0de</Hash>
</Codenesium>*/