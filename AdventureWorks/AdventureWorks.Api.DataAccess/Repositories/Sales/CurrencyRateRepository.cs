using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CurrencyRateRepository: AbstractCurrencyRateRepository, ICurrencyRateRepository
        {
                public CurrencyRateRepository(
                        ILogger<CurrencyRateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f277183ffb0b6b833fc5d39471afd406</Hash>
</Codenesium>*/