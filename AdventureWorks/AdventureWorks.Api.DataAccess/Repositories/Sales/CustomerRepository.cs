using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CustomerRepository : AbstractCustomerRepository, ICustomerRepository
        {
                public CustomerRepository(
                        ILogger<CustomerRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e977df42125fcfceca961f3370d92a24</Hash>
</Codenesium>*/