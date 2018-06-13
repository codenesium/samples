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
        public class CurrencyService: AbstractCurrencyService, ICurrencyService
        {
                public CurrencyService(
                        ILogger<CurrencyRepository> logger,
                        ICurrencyRepository currencyRepository,
                        IApiCurrencyRequestModelValidator currencyModelValidator,
                        IBOLCurrencyMapper bolcurrencyMapper,
                        IDALCurrencyMapper dalcurrencyMapper
                        ,
                        IBOLCountryRegionCurrencyMapper bolCountryRegionCurrencyMapper,
                        IDALCountryRegionCurrencyMapper dalCountryRegionCurrencyMapper
                        ,
                        IBOLCurrencyRateMapper bolCurrencyRateMapper,
                        IDALCurrencyRateMapper dalCurrencyRateMapper

                        )
                        : base(logger,
                               currencyRepository,
                               currencyModelValidator,
                               bolcurrencyMapper,
                               dalcurrencyMapper
                               ,
                               bolCountryRegionCurrencyMapper,
                               dalCountryRegionCurrencyMapper
                               ,
                               bolCurrencyRateMapper,
                               dalCurrencyRateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce198a767fd3206126400480d0029b9c</Hash>
</Codenesium>*/