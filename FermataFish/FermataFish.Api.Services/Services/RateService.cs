using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class RateService: AbstractRateService, IRateService
	{
		public RateService(
			ILogger<RateRepository> logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper BOLrateMapper,
			IDALRateMapper DALrateMapper)
			: base(logger, rateRepository,
			       rateModelValidator,
			       BOLrateMapper,
			       DALrateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>62b6e1ff88455e192049919802689cc1</Hash>
</Codenesium>*/