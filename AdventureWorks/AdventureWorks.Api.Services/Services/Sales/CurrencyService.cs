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
                        ILogger<ICurrencyRepository> logger,
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
    <Hash>cfcf10f5b9bf5d702d4ff4908e04f406</Hash>
</Codenesium>*/