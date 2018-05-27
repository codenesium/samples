using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BORate:AbstractBORate, IBORate
	{
		public BORate(
			ILogger<RateRepository> logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper rateMapper)
			: base(logger, rateRepository, rateModelValidator, rateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7c7008b49d17d5e4a0203f8088c56ad4</Hash>
</Codenesium>*/