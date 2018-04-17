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
	public class BODatabaseLog: AbstractBODatabaseLog, IBODatabaseLog
	{
		public BODatabaseLog(
			ILogger<DatabaseLogRepository> logger,
			IDatabaseLogRepository databaseLogRepository,
			IDatabaseLogModelValidator databaseLogModelValidator)
			: base(logger, databaseLogRepository, databaseLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a68f10ad2608403e30a7ad877680a03d</Hash>
</Codenesium>*/