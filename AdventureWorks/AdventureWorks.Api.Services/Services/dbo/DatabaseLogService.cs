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
			IDALDatabaseLogMapper daldatabaseLogMapper
			)
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
    <Hash>5aa4bff66f1037c0d5e14cce5d73418a</Hash>
</Codenesium>*/