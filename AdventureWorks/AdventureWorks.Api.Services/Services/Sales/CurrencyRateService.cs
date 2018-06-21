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
        public class CurrencyRateService : AbstractCurrencyRateService, ICurrencyRateService
        {
                public CurrencyRateService(
                        ILogger<ICurrencyRateRepository> logger,
                        ICurrencyRateRepository currencyRateRepository,
                        IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
                        IBOLCurrencyRateMapper bolcurrencyRateMapper,
                        IDALCurrencyRateMapper dalcurrencyRateMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        )
                        : base(logger,
                               currencyRateRepository,
                               currencyRateModelValidator,
                               bolcurrencyRateMapper,
                               dalcurrencyRateMapper,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e48773e2cb491a824b1e63a2b0ea2042</Hash>
</Codenesium>*/