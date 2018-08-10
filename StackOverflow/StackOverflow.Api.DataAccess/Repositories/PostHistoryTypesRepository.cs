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
    <Hash>e7a339b39d302d8ce640417c96012a4e</Hash>
</Codenesium>*/