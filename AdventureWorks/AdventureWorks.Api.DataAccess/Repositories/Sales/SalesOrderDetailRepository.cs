using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesOrderDetailRepository : AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
        {
                public SalesOrderDetailRepository(
                        ILogger<SalesOrderDetailRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b526aa06a57d3cd8fc6bfa357eb8451f</Hash>
</Codenesium>*/