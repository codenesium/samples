using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class TimestampCheckService : AbstractTimestampCheckService, ITimestampCheckService
	{
		public TimestampCheckService(
			ILogger<ITimestampCheckRepository> logger,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckRequestModelValidator timestampCheckModelValidator,
			IBOLTimestampCheckMapper boltimestampCheckMapper,
			IDALTimestampCheckMapper daltimestampCheckMapper
			)
			: base(logger,
			       timestampCheckRepository,
			       timestampCheckModelValidator,
			       boltimestampCheckMapper,
			       daltimestampCheckMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>594314098ef549067ac7576fef4d024c</Hash>
</Codenesium>*/