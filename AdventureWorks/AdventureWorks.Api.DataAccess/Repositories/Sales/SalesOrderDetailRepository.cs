using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesOrderDetailRepository: AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
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
    <Hash>b9fa8770c81a099ed7ef7443bb9e921d</Hash>
</Codenesium>*/