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
        [Route("api/salesReasons")]
        [ApiVersion("1.0")]
        public class SalesReasonController: AbstractSalesReasonController
        {
                public SalesReasonController(
                        ServiceSettings settings,
                        ILogger<SalesReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesReasonService salesReasonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesReasonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>29d6d7f8a263552fa5935226987bfe33</Hash>
</Codenesium>*/