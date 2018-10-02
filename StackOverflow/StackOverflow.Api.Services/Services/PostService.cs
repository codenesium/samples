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
	public partial class PostService : AbstractPostService, IPostService
	{
		public PostService(
			ILogger<IPostRepository> logger,
			IPostRepository postRepository,
			IApiPostRequestModelValidator postModelValidator,
			IBOLPostMapper bolpostMapper,
			IDALPostMapper dalpostMapper
			)
			: base(logger,
			       postRepository,
			       postModelValidator,
			       bolpostMapper,
			       dalpostMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ea23008fe7c25dd8f4ea07d442a1adb6</Hash>
</Codenesium>*/