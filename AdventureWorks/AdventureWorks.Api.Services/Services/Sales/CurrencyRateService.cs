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
                        IDALCurrencyRateMapper dalcurrencyRateMapper)
                        : base(logger,
                               currencyRateRepository,
                               currencyRateModelValidator,
                               bolcurrencyRateMapper,
                               dalcurrencyRateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a81c73a326929039ac4296a45557693c</Hash>
</Codenesium>*/