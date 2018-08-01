using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>00ce80a3ab62473dcd0383667190c888</Hash>
</Codenesium>*/