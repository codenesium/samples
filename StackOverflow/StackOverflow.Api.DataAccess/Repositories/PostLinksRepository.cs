using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>7c4857ed37454b974ce63fb5a8056bef</Hash>
</Codenesium>*/