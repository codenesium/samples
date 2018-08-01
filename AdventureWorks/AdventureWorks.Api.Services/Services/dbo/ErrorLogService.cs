using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ErrorLogService : AbstractErrorLogService, IErrorLogService
	{
		public ErrorLogService(
			ILogger<IErrorLogRepository> logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolerrorLogMapper,
			IDALErrorLogMapper dalerrorLogMapper
			)
			: base(logger,
			       errorLogRepository,
			       errorLogModelValidator,
			       bolerrorLogMapper,
			       dalerrorLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>19bdf4e61f4973b9b2b2e98deb9db0ae</Hash>
</Codenesium>*/