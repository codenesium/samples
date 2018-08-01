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
	public partial class PostLinksService : AbstractPostLinksService, IPostLinksService
	{
		public PostLinksService(
			ILogger<IPostLinksRepository> logger,
			IPostLinksRepository postLinksRepository,
			IApiPostLinksRequestModelValidator postLinksModelValidator,
			IBOLPostLinksMapper bolpostLinksMapper,
			IDALPostLinksMapper dalpostLinksMapper
			)
			: base(logger,
			       postLinksRepository,
			       postLinksModelValidator,
			       bolpostLinksMapper,
			       dalpostLinksMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>907b2e2a23d17d08879d303d094f0f95</Hash>
</Codenesium>*/