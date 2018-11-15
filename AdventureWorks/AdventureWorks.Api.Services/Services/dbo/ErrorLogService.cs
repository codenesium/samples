using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ErrorLogService : AbstractErrorLogService, IErrorLogService
	{
		public ErrorLogService(
			ILogger<IErrorLogRepository> logger,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogServerRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolErrorLogMapper,
			IDALErrorLogMapper dalErrorLogMapper)
			: base(logger,
			       errorLogRepository,
			       errorLogModelValidator,
			       bolErrorLogMapper,
			       dalErrorLogMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc4cfeb971fac2265334d32b9bc04f1f</Hash>
</Codenesium>*/