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
			IDALPostHistoryTypeMapper dalpostHistoryTypeMapper)
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
    <Hash>4a0dbe727a6f726a124c8ff45fce04af</Hash>
</Codenesium>*/