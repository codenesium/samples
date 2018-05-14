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
			IApiRateModelValidator rateModelValidator)
			: base(logger, rateRepository, rateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>37649e3ccffb40987ac4f65b9c70ff0f</Hash>
</Codenesium>*/