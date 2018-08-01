using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>789496398e4e8e0f0d5511deb23c2f04</Hash>
</Codenesium>*/