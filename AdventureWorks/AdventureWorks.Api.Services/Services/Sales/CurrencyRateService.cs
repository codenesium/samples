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
                        IBOLCurrencyRateMapper bolcurrencyRateMapper,
                        IDALCurrencyRateMapper dalcurrencyRateMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper

                        )
                        : base(logger,
                               currencyRateRepository,
                               currencyRateModelValidator,
                               bolcurrencyRateMapper,
                               dalcurrencyRateMapper
                               ,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>5769d8d441ad4c8fe8a79052540f0e11</Hash>
</Codenesium>*/