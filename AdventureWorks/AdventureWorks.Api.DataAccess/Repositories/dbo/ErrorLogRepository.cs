using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ErrorLogRepository: AbstractErrorLogRepository, IErrorLogRepository
	{
		public ErrorLogRepository(
			IDALErrorLogMapper mapper,
			ILogger<ErrorLogRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ae954d0eec1e2e5f421abb003263b5f5</Hash>
</Codenesium>*/