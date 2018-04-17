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
			IErrorLogModelValidator errorLogModelValidator)
			: base(logger, errorLogRepository, errorLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>1855bd542c7050acaf2e9c89268611c8</Hash>
</Codenesium>*/