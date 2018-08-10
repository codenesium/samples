using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>9efed38879f1d181f1cf42e73b01f797</Hash>
</Codenesium>*/