using MediatR;
using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TimestampCheckService : AbstractTimestampCheckService, ITimestampCheckService
	{
		public TimestampCheckService(
			ILogger<ITimestampCheckRepository> logger,
			IMediator mediator,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckServerRequestModelValidator timestampCheckModelValidator,
			IDALTimestampCheckMapper dalTimestampCheckMapper)
			: base(logger,
			       mediator,
			       timestampCheckRepository,
			       timestampCheckModelValidator,
			       dalTimestampCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>baf03a275acce86d1db134cd55f87914</Hash>
</Codenesium>*/