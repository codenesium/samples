using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesTaxRateRepository : AbstractSalesTaxRateRepository, ISalesTaxRateRepository
        {
                public SalesTaxRateRepository(
                        ILogger<SalesTaxRateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8c70b6cf6dfd488594e8e154e9476006</Hash>
</Codenesium>*/