using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/saleTickets")]
        [ApiVersion("1.0")]
        public class SaleTicketsController : AbstractSaleTicketsController
        {
                public SaleTicketsController(
                        ApiSettings settings,
                        ILogger<SaleTicketsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleTicketsService saleTicketsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               saleTicketsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9bd2593016855c462b92a4e7c9e7e147</Hash>
</Codenesium>*/