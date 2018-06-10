using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class CustomerService: AbstractCustomerService, ICustomerService
        {
                public CustomerService(
                        ILogger<CustomerRepository> logger,
                        ICustomerRepository customerRepository,
                        IApiCustomerRequestModelValidator customerModelValidator,
                        IBOLCustomerMapper bolcustomerMapper,
                        IDALCustomerMapper dalcustomerMapper)
                        : base(logger,
                               customerRepository,
                               customerModelValidator,
                               bolcustomerMapper,
                               dalcustomerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4994d5c013b054ed4219d001af94a7e7</Hash>
</Codenesium>*/