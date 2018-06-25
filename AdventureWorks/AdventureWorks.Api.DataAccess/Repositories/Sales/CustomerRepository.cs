using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CustomerRepository : AbstractCustomerRepository, ICustomerRepository
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
    <Hash>7ca7a2b8bd9af7fb1ff2370c79bf5aa8</Hash>
</Codenesium>*/