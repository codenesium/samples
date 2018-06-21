using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CountryRegionCurrencyRepository : AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
        {
                public CountryRegionCurrencyRepository(
                        ILogger<CountryRegionCurrencyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7d0a9a9db10e83a020e51ad3cb351937</Hash>
</Codenesium>*/