using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>044b0ce6ec49a1b67da10779358ca980</Hash>
</Codenesium>*/