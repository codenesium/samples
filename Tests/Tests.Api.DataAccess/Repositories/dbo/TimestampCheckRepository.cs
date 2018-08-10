using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial class TimestampCheckRepository : AbstractTimestampCheckRepository, ITimestampCheckRepository
	{
		public TimestampCheckRepository(
			ILogger<TimestampCheckRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b18e4d7b72f6374cc887557411e923d4</Hash>
</Codenesium>*/