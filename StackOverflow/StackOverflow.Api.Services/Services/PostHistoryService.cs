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
	public partial class PostHistoryService : AbstractPostHistoryService, IPostHistoryService
	{
		public PostHistoryService(
			ILogger<IPostHistoryRepository> logger,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolpostHistoryMapper,
			IDALPostHistoryMapper dalpostHistoryMapper
			)
			: base(logger,
			       postHistoryRepository,
			       postHistoryModelValidator,
			       bolpostHistoryMapper,
			       dalpostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e7e7d077405cf33a2f3cc85278e2776d</Hash>
</Codenesium>*/