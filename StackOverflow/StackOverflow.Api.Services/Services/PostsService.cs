using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0186d1a42b527cbf7527248ab9a0f32e</Hash>
</Codenesium>*/