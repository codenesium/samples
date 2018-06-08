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
                        IDALCurrencyMapper dalcurrencyMapper)
                        : base(logger,
                               currencyRepository,
                               currencyModelValidator,
                               bolcurrencyMapper,
                               dalcurrencyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3f42437b3049bac701f1c1e536379469</Hash>
</Codenesium>*/