using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ErrorLogRepository : AbstractErrorLogRepository, IErrorLogRepository
	{
		public ErrorLogRepository(
			ILogger<ErrorLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>59e27c70cf96f7e047c2b7ec1de8791a</Hash>
</Codenesium>*/