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
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base(logger,
			       mediator,
			       databaseLogRepository,
			       databaseLogModelValidator,
			       dalDatabaseLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cc3a0069ef673d841918772c2d145f07</Hash>
</Codenesium>*/