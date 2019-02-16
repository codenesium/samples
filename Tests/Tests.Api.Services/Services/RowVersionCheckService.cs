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
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base(logger,
			       mediator,
			       rowVersionCheckRepository,
			       rowVersionCheckModelValidator,
			       dalRowVersionCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0760295a2a24f72cb35b9f24c1f5c9de</Hash>
</Codenesium>*/