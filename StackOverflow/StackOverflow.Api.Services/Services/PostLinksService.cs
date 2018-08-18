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
    <Hash>a00c7bded89784427fb9c4f447f98d91</Hash>
</Codenesium>*/