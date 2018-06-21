using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CurrencyRateRepository : AbstractCurrencyRateRepository, ICurrencyRateRepository
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
    <Hash>bfe1e3f170b93d3a5db8549cb947e66d</Hash>
</Codenesium>*/