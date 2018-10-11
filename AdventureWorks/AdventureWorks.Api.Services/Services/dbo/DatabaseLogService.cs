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
	public partial class DatabaseLogService : AbstractDatabaseLogService, IDatabaseLogService
	{
		public DatabaseLogService(
			ILogger<IDatabaseLogRepository> logger,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper boldatabaseLogMapper,
			IDALDatabaseLogMapper daldatabaseLogMapper)
			: base(logger,
			       databaseLogRepository,
			       databaseLogModelValidator,
			       boldatabaseLogMapper,
			       daldatabaseLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4dc548bf77d6d877e85b73f5046f8cce</Hash>
</Codenesium>*/