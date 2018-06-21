using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>8428b771b1d7e6e19259f8c5412f0923</Hash>
</Codenesium>*/