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
	public partial class PostHistoryTypeRepository : AbstractPostHistoryTypeRepository, IPostHistoryTypeRepository
	{
		public PostHistoryTypeRepository(
			ILogger<PostHistoryTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c72aad9533a061d87d9cffdb7281896</Hash>
</Codenesium>*/