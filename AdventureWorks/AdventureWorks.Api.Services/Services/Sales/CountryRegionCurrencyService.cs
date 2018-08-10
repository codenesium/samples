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
	public partial class CountryRegionCurrencyService : AbstractCountryRegionCurrencyService, ICountryRegionCurrencyService
	{
		public CountryRegionCurrencyService(
			ILogger<ICountryRegionCurrencyRepository> logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
			IBOLCountryRegionCurrencyMapper bolcountryRegionCurrencyMapper,
			IDALCountryRegionCurrencyMapper dalcountryRegionCurrencyMapper
			)
			: base(logger,
			       countryRegionCurrencyRepository,
			       countryRegionCurrencyModelValidator,
			       bolcountryRegionCurrencyMapper,
			       dalcountryRegionCurrencyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>abf7cb9b1b280fadeac1599578f283fe</Hash>
</Codenesium>*/