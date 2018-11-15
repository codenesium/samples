using Microsoft.Extensions.Logging;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TimestampCheckService : AbstractTimestampCheckService, ITimestampCheckService
	{
		public TimestampCheckService(
			ILogger<ITimestampCheckRepository> logger,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckServerRequestModelValidator timestampCheckModelValidator,
			IBOLTimestampCheckMapper bolTimestampCheckMapper,
			IDALTimestampCheckMapper dalTimestampCheckMapper)
			: base(logger,
			       timestampCheckRepository,
			       timestampCheckModelValidator,
			       bolTimestampCheckMapper,
			       dalTimestampCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a23798ba8885400a779afdb9b6724335</Hash>
</Codenesium>*/