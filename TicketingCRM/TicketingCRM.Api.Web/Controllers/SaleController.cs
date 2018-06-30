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
        [Route("api/sales")]
        [ApiVersion("1.0")]
        public class SaleController : AbstractSaleController
        {
                public SaleController(
                        ApiSettings settings,
                        ILogger<SaleController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleService saleService,
                        IApiSaleModelMapper saleModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               saleService,
                               saleModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>914276061e0350df5bad530c2e2ed50e</Hash>
</Codenesium>*/