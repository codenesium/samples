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
			IApiDatabaseLogModelValidator databaseLogModelValidator)
			: base(logger, databaseLogRepository, databaseLogModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4071415fb83f9e2e00618ac6c1c6b041</Hash>
</Codenesium>*/