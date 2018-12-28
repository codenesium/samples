using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ErrorLogService : AbstractErrorLogService, IErrorLogService
	{
		public ErrorLogService(
			ILogger<IErrorLogRepository> logger,
			IMediator mediator,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogServerRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolErrorLogMapper,
			IDALErrorLogMapper dalErrorLogMapper)
			: base(logger,
			       mediator,
			       errorLogRepository,
			       errorLogModelValidator,
			       bolErrorLogMapper,
			       dalErrorLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>89dfea3c3892df0b7450b346495a4cad</Hash>
</Codenesium>*/