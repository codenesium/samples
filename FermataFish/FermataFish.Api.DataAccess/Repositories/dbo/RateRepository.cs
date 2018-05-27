using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class RateRepository: AbstractRateRepository, IRateRepository
	{
		public RateRepository(
			IDALRateMapper mapper,
			ILogger<RateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>6dc1bf50abf91d599181c3ddde73359a</Hash>
</Codenesium>*/