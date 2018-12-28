using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DatabaseLogService : AbstractDatabaseLogService, IDatabaseLogService
	{
		public DatabaseLogService(
			ILogger<IDatabaseLogRepository> logger,
			IMediator mediator,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogServerRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper bolDatabaseLogMapper,
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base(logger,
			       mediator,
			       databaseLogRepository,
			       databaseLogModelValidator,
			       bolDatabaseLogMapper,
			       dalDatabaseLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>00fa34080b0cbb816c9a63ca3efe6c5b</Hash>
</Codenesium>*/