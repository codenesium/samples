using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/salesPersons")]
        [ApiVersion("1.0")]
        public class SalesPersonController: AbstractSalesPersonController
        {
                public SalesPersonController(
                        ServiceSettings settings,
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
    <Hash>4058f83f42ad9b399728a1af6f4f4b90</Hash>
</Codenesium>*/