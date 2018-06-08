using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesReasonRepository: AbstractSalesReasonRepository, ISalesReasonRepository
        {
                public SalesReasonRepository(
                        ILogger<SalesReasonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>25de1d6ce109e4e7aa19b44c0afc373b</Hash>
</Codenesium>*/