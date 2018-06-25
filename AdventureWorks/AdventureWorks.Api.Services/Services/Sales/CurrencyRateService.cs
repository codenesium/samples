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
        public partial class CurrencyRateService : AbstractCurrencyRateService, ICurrencyRateService
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
    <Hash>f5c0e98f22f31b49bfcfc185caabf9e3</Hash>
</Codenesium>*/