using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CurrencyRateService: AbstractCurrencyRateService, ICurrencyRateService
	{
		public CurrencyRateService(
			ILogger<CurrencyRateRepository> logger,
			ICurrencyRateRepository currencyRateRepository,
			IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper BOLcurrencyRateMapper,
			IDALCurrencyRateMapper DALcurrencyRateMapper)
			: base(logger, currencyRateRepository,
			       currencyRateModelValidator,
			       BOLcurrencyRateMapper,
			       DALcurrencyRateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8dd966d14be1f05a850fec17d0f94b73</Hash>
</Codenesium>*/