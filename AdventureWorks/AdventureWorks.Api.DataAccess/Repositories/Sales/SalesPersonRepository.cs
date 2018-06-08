using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesPersonRepository: AbstractSalesPersonRepository, ISalesPersonRepository
        {
                public SalesPersonRepository(
                        ILogger<SalesPersonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5801d9b3a3869dfd49b7eb486e60d85b</Hash>
</Codenesium>*/