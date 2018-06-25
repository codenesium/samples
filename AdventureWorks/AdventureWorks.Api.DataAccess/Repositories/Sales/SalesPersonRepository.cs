using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesPersonRepository : AbstractSalesPersonRepository, ISalesPersonRepository
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
    <Hash>5489c1b87710f4d9eb89a8cfdefd9168</Hash>
</Codenesium>*/