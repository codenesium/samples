using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesOrderDetailRepository : AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
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
    <Hash>646397c2fe31c4559ce805f69ac3fd5b</Hash>
</Codenesium>*/