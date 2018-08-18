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
	public partial class RowVersionCheckRepository : AbstractRowVersionCheckRepository, IRowVersionCheckRepository
	{
		public RowVersionCheckRepository(
			ILogger<RowVersionCheckRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ab5536dcccf2435f3d45348e0cb8fa5f</Hash>
</Codenesium>*/