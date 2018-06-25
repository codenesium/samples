using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CurrencyRateRepository : AbstractCurrencyRateRepository, ICurrencyRateRepository
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
    <Hash>e730ae98872b0be24dffd55ce1f2e414</Hash>
</Codenesium>*/