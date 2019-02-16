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
			IDALErrorLogMapper dalErrorLogMapper)
			: base(logger,
			       mediator,
			       errorLogRepository,
			       errorLogModelValidator,
			       dalErrorLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>11e95ccd386d2eb0235c48685ea93638</Hash>
</Codenesium>*/