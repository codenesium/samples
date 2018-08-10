using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial class PostsService : AbstractPostsService, IPostsService
	{
		public PostsService(
			ILogger<IPostsRepository> logger,
			IPostsRepository postsRepository,
			IApiPostsRequestModelValidator postsModelValidator,
			IBOLPostsMapper bolpostsMapper,
			IDALPostsMapper dalpostsMapper
			)
			: base(logger,
			       postsRepository,
			       postsModelValidator,
			       bolpostsMapper,
			       dalpostsMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>914a82612ab333b0d02519e0facb0cc0</Hash>
</Codenesium>*/