using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOErrorLog: AbstractBOErrorLog, IBOErrorLog
	{
		public BOErrorLog(
			ILogger<ErrorLogRepository> logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper errorLogMapper)
			: base(logger, errorLogRepository, errorLogModelValidator, errorLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>9d967a39aba895a54df85933993aeea9</Hash>
</Codenesium>*/