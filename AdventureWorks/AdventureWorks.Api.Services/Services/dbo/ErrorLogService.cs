using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ErrorLogService: AbstractErrorLogService, IErrorLogService
	{
		public ErrorLogService(
			ILogger<ErrorLogRepository> logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper BOLerrorLogMapper,
			IDALErrorLogMapper DALerrorLogMapper)
			: base(logger, errorLogRepository,
			       errorLogModelValidator,
			       BOLerrorLogMapper,
			       DALerrorLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dcdc412277e91f57ba7d3ed4b83dcced</Hash>
</Codenesium>*/