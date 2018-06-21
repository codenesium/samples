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
        public class CurrencyService : AbstractCurrencyService, ICurrencyService
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
    <Hash>609aa1b4f07e9cd2e994129e24422052</Hash>
</Codenesium>*/