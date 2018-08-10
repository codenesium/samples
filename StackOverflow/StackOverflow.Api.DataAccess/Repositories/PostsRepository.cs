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
    <Hash>1419ab0587bb7ac86f5114fc4630bef9</Hash>
</Codenesium>*/