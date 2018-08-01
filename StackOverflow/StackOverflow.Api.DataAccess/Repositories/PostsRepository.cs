using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
	public partial class PostsRepository : AbstractPostsRepository, IPostsRepository
	{
		public PostsRepository(
			ILogger<PostsRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bdacadc6e743c52ac4a27242a5f976e3</Hash>
</Codenesium>*/