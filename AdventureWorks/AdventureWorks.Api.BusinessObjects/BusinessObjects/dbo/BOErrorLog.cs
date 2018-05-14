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
			IApiErrorLogModelValidator errorLogModelValidator)
			: base(logger, errorLogRepository, errorLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a98b3b43cdd6d26bf3f42c220174a896</Hash>
</Codenesium>*/