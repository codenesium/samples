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
			IRateModelValidator rateModelValidator)
			: base(logger, rateRepository, rateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>7440ba188d10315eda9852f9db578ed5</Hash>
</Codenesium>*/