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
    <Hash>a1caaf767c4bfeddef8bb302ac3318a7</Hash>
</Codenesium>*/