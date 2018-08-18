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
	public partial class PostTypesService : AbstractPostTypesService, IPostTypesService
	{
		public PostTypesService(
			ILogger<IPostTypesRepository> logger,
			IPostTypesRepository postTypesRepository,
			IApiPostTypesRequestModelValidator postTypesModelValidator,
			IBOLPostTypesMapper bolpostTypesMapper,
			IDALPostTypesMapper dalpostTypesMapper
			)
			: base(logger,
			       postTypesRepository,
			       postTypesModelValidator,
			       bolpostTypesMapper,
			       dalpostTypesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7914de12f881f270d3091e2aa2190a69</Hash>
</Codenesium>*/