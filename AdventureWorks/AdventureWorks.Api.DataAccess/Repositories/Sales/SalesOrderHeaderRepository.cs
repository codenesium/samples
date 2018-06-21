using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesOrderHeaderRepository : AbstractSalesOrderHeaderRepository, ISalesOrderHeaderRepository
        {
                public SalesOrderHeaderRepository(
                        ILogger<SalesOrderHeaderRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce1a20616760b8bec1b835b01b5aa690</Hash>
</Codenesium>*/