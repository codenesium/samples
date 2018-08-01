using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public partial class RateRepository : AbstractRateRepository, IRateRepository
	{
		public RateRepository(
			ILogger<RateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3564a97e6980414670c4bf66e8befa3f</Hash>
</Codenesium>*/