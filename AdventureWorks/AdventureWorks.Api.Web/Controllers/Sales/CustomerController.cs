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
        [ApiController]
        [ApiVersion("1.0")]
        public class CustomerController : AbstractCustomerController
        {
                public CustomerController(
                        ApiSettings settings,
                        ILogger<CustomerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICustomerService customerService,
                        IApiCustomerModelMapper customerModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               customerService,
                               customerModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>32d88421ef902a32e9ec971d2108d468</Hash>
</Codenesium>*/