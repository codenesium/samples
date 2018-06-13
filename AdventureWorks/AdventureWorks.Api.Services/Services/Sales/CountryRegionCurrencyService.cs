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
        public class CountryRegionCurrencyService: AbstractCountryRegionCurrencyService, ICountryRegionCurrencyService
        {
                public CountryRegionCurrencyService(
                        ILogger<CountryRegionCurrencyRepository> logger,
                        ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
                        IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
                        IBOLCountryRegionCurrencyMapper bolcountryRegionCurrencyMapper,
                        IDALCountryRegionCurrencyMapper dalcountryRegionCurrencyMapper

                        )
                        : base(logger,
                               countryRegionCurrencyRepository,
                               countryRegionCurrencyModelValidator,
                               bolcountryRegionCurrencyMapper,
                               dalcountryRegionCurrencyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>de4834201a16354add11585aa85eb9d7</Hash>
</Codenesium>*/