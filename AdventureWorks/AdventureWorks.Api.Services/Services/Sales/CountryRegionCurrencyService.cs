using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>3f683dc2b83c0a2f11aa634e886959ba</Hash>
</Codenesium>*/