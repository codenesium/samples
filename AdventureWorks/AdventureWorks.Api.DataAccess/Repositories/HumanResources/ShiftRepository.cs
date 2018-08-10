using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ShiftRepository : AbstractShiftRepository, IShiftRepository
	{
		public ShiftRepository(
			ILogger<ShiftRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d7028f3b8eaf2444036dc8fbf525f3ad</Hash>
</Codenesium>*/