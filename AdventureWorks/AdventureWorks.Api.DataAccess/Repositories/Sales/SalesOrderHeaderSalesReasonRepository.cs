using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesOrderHeaderSalesReasonRepository : AbstractSalesOrderHeaderSalesReasonRepository, ISalesOrderHeaderSalesReasonRepository
        {
                public SalesOrderHeaderSalesReasonRepository(
                        ILogger<SalesOrderHeaderSalesReasonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b00462e2c5bc69867c6e62508aa850a2</Hash>
</Codenesium>*/