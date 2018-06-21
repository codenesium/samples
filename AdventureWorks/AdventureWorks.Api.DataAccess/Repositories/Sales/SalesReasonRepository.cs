using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesReasonRepository : AbstractSalesReasonRepository, ISalesReasonRepository
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
    <Hash>ac4c14d3d93288d4d84b64a8e84cef87</Hash>
</Codenesium>*/