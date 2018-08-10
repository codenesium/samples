using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class CurrencyService : AbstractCurrencyService, ICurrencyService
	{
		public CurrencyService(
			ILogger<ICurrencyRepository> logger,
			ICurrencyRepository currencyRepository,
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper bolcurrencyMapper,
			IDALCurrencyMapper dalcurrencyMapper,
			IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
			IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper,
			IBOLCurrencyRateMapper bolCurrencyRateMapper,
			IDALCurrencyRateMapper dalCurrencyRateMapper
			)
			: base(logger,
			       currencyRepository,
			       currencyModelValidator,
			       bolcurrencyMapper,
			       dalcurrencyMapper,
			       bolCountryRegionCurrencyMapper,
			       dalCountryRegionCurrencyMapper,
			       bolCurrencyRateMapper,
			       dalCurrencyRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>131fa771ff000a49e733494f76d5f6b8</Hash>
</Codenesium>*/