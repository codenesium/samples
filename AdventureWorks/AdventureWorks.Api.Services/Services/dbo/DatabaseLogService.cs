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
	public class DatabaseLogService: AbstractDatabaseLogService, IDatabaseLogService
	{
		public DatabaseLogService(
			ILogger<DatabaseLogRepository> logger,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper BOLdatabaseLogMapper,
			IDALDatabaseLogMapper DALdatabaseLogMapper)
			: base(logger, databaseLogRepository,
			       databaseLogModelValidator,
			       BOLdatabaseLogMapper,
			       DALdatabaseLogMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>e189a431cf207e9baebb93527945be7e</Hash>
</Codenesium>*/