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
    <Hash>8b1e37ce62171eee189c4fd62e48249e</Hash>
</Codenesium>*/