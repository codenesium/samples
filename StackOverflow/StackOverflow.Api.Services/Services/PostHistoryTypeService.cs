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
	public partial class PostHistoryTypeService : AbstractPostHistoryTypeService, IPostHistoryTypeService
	{
		public PostHistoryTypeService(
			ILogger<IPostHistoryTypeRepository> logger,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeRequestModelValidator postHistoryTypeModelValidator,
			IBOLPostHistoryTypeMapper bolpostHistoryTypeMapper,
			IDALPostHistoryTypeMapper dalpostHistoryTypeMapper
			)
			: base(logger,
			       postHistoryTypeRepository,
			       postHistoryTypeModelValidator,
			       bolpostHistoryTypeMapper,
			       dalpostHistoryTypeMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ff450f4847d096cf403f1e9f4bd378b6</Hash>
</Codenesium>*/