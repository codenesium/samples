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
	public partial class PostHistoryTypesService : AbstractPostHistoryTypesService, IPostHistoryTypesService
	{
		public PostHistoryTypesService(
			ILogger<IPostHistoryTypesRepository> logger,
			IPostHistoryTypesRepository postHistoryTypesRepository,
			IApiPostHistoryTypesRequestModelValidator postHistoryTypesModelValidator,
			IBOLPostHistoryTypesMapper bolpostHistoryTypesMapper,
			IDALPostHistoryTypesMapper dalpostHistoryTypesMapper
			)
			: base(logger,
			       postHistoryTypesRepository,
			       postHistoryTypesModelValidator,
			       bolpostHistoryTypesMapper,
			       dalpostHistoryTypesMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b6a00b84a5624746cc04aee4db2a0a3f</Hash>
</Codenesium>*/