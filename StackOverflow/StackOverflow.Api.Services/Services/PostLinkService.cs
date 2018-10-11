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
	public partial class PostLinkService : AbstractPostLinkService, IPostLinkService
	{
		public PostLinkService(
			ILogger<IPostLinkRepository> logger,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkRequestModelValidator postLinkModelValidator,
			IBOLPostLinkMapper bolpostLinkMapper,
			IDALPostLinkMapper dalpostLinkMapper)
			: base(logger,
			       postLinkRepository,
			       postLinkModelValidator,
			       bolpostLinkMapper,
			       dalpostLinkMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>17d7cd9072afca013650a2308e356a2c</Hash>
</Codenesium>*/