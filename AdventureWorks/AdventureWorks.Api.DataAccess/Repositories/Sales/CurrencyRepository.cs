using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CurrencyRepository : AbstractCurrencyRepository, ICurrencyRepository
        {
                public CurrencyRepository(
                        ILogger<CurrencyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f540894a108d408f221fdf494e0a8dc2</Hash>
</Codenesium>*/