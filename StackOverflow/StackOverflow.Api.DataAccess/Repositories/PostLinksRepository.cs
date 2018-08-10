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
	public partial class PostLinksRepository : AbstractPostLinksRepository, IPostLinksRepository
	{
		public PostLinksRepository(
			ILogger<PostLinksRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2f04e8f43db38c567231f7cfb7c5c504</Hash>
</Codenesium>*/