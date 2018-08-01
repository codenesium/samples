using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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
    <Hash>85562e11193c85139112b646d25e359e</Hash>
</Codenesium>*/