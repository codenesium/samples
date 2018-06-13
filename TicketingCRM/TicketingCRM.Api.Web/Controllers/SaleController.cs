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
        [Route("api/sales")]
        [ApiVersion("1.0")]
        public class SaleController: AbstractSaleController
        {
                public SaleController(
                        ServiceSettings settings,
                        ILogger<SaleController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleService saleService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               saleService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7bee9fffb4f559f4df71b58d1a478497</Hash>
</Codenesium>*/