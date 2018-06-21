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
        [Route("api/salesPersons")]
        [ApiVersion("1.0")]
        public class SalesPersonController : AbstractSalesPersonController
        {
                public SalesPersonController(
                        ApiSettings settings,
                        ILogger<SalesPersonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesPersonService salesPersonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesPersonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3bd33f726464328fb2459bc33a41d82e</Hash>
</Codenesium>*/