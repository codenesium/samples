using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class RowVersionCheckService : AbstractRowVersionCheckService, IRowVersionCheckService
	{
		public RowVersionCheckService(
			ILogger<IRowVersionCheckRepository> logger,
			IMediator mediator,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckServerRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolRowVersionCheckMapper,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base(logger,
			       mediator,
			       rowVersionCheckRepository,
			       rowVersionCheckModelValidator,
			       bolRowVersionCheckMapper,
			       dalRowVersionCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eafbcec9a65f09a2c0c356e4044779fa</Hash>
</Codenesium>*/