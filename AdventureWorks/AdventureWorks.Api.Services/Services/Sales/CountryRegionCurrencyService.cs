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
        public class CountryRegionCurrencyService : AbstractCountryRegionCurrencyService, ICountryRegionCurrencyService
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
    <Hash>8fd16b28d8a449b85728a9f8a1260117</Hash>
</Codenesium>*/