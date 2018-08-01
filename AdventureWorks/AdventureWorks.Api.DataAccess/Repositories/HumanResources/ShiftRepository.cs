using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>f1a163dbba705fdcef1e689af3e8ce6e</Hash>
</Codenesium>*/