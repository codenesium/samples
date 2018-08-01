using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
	public partial class ClaspRepository : AbstractClaspRepository, IClaspRepository
	{
		public ClaspRepository(
			ILogger<ClaspRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fa0f2590da5c08de0ef790528372afce</Hash>
</Codenesium>*/