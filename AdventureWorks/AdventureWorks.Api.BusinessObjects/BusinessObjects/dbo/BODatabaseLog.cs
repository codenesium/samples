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
			IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper databaseLogMapper)
			: base(logger, databaseLogRepository, databaseLogModelValidator, databaseLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>93f01884b989ffd0483f183622d52c02</Hash>
</Codenesium>*/