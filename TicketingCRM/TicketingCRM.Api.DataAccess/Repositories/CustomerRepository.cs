using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class CustomerRepository: AbstractCustomerRepository, ICustomerRepository
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
    <Hash>a06207c0f01149808e319da6237b7514</Hash>
</Codenesium>*/