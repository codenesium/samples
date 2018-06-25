using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CountryRegionCurrencyRepository : AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
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
    <Hash>0bb6091e36ddc65a6837e2ebcd1ffec7</Hash>
</Codenesium>*/