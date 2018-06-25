using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesOrderHeaderRepository : AbstractSalesOrderHeaderRepository, ISalesOrderHeaderRepository
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
    <Hash>e41884bc77f1f4c3fc20e51517fab0b7</Hash>
</Codenesium>*/