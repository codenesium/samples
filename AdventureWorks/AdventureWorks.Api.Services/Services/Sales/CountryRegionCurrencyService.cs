using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>d226fc1043526920a41815d66174a05f</Hash>
</Codenesium>*/