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
			IBOLTimestampCheckMapper bolTimestampCheckMapper,
			IDALTimestampCheckMapper dalTimestampCheckMapper)
			: base(logger,
			       mediator,
			       timestampCheckRepository,
			       timestampCheckModelValidator,
			       bolTimestampCheckMapper,
			       dalTimestampCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6cda00c34bce281b64134f7e6ee5c7d4</Hash>
</Codenesium>*/