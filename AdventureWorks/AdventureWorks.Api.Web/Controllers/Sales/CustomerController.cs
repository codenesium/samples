using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/customers")]
        [ApiVersion("1.0")]
        public class CustomerController : AbstractCustomerController
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
    <Hash>062b464233d0d3cf7e94eff549720d4c</Hash>
</Codenesium>*/