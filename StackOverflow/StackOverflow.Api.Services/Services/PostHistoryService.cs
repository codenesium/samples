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
    <Hash>70bd7386fe14c1921c2484561dec1479</Hash>
</Codenesium>*/