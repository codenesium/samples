using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class RateRepository: AbstractRateRepository, IRateRepository
	{
		public RateRepository(
			ILogger<RateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>be5f3dd200e5be2261a06fc1f4c2b5c4</Hash>
</Codenesium>*/