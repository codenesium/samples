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
    <Hash>550d810c3391b60822e5b8d05862dfdc</Hash>
</Codenesium>*/