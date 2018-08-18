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
    <Hash>23ec756e21f4d329c7adc99e6cc01b8d</Hash>
</Codenesium>*/