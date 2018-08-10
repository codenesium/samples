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
    <Hash>643676d1b8618b8fa54d309dff43c14c</Hash>
</Codenesium>*/