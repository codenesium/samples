using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>e724cca3753e5cc5192747ff32fd5ac0</Hash>
</Codenesium>*/