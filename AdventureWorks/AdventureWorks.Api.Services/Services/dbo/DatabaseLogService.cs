using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DatabaseLogService : AbstractDatabaseLogService, IDatabaseLogService
	{
		public DatabaseLogService(
			ILogger<IDatabaseLogRepository> logger,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogServerRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper bolDatabaseLogMapper,
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base(logger,
			       databaseLogRepository,
			       databaseLogModelValidator,
			       bolDatabaseLogMapper,
			       dalDatabaseLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>08794bb5bffa2a39b0413331df7b21ad</Hash>
</Codenesium>*/