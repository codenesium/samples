using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class RowVersionCheckService : AbstractRowVersionCheckService, IRowVersionCheckService
	{
		public RowVersionCheckService(
			ILogger<IRowVersionCheckRepository> logger,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckServerRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolRowVersionCheckMapper,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base(logger,
			       rowVersionCheckRepository,
			       rowVersionCheckModelValidator,
			       bolRowVersionCheckMapper,
			       dalRowVersionCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fd9618d7908670846213725779c47e5a</Hash>
</Codenesium>*/