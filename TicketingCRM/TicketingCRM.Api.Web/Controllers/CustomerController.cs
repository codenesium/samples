using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/customers")]
        [ApiVersion("1.0")]
        public class CustomerController: AbstractCustomerController
        {
                public CustomerController(
                        ApiSettings settings,
                        ILogger<CustomerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICustomerService customerService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               customerService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c8393d636c1e435cfeb89f5f55564758</Hash>
</Codenesium>*/