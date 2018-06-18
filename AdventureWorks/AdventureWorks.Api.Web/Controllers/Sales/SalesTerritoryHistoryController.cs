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
        [Route("api/salesTerritoryHistories")]
        [ApiVersion("1.0")]
        public class SalesTerritoryHistoryController: AbstractSalesTerritoryHistoryController
        {
                public SalesTerritoryHistoryController(
                        ApiSettings settings,
                        ILogger<SalesTerritoryHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTerritoryHistoryService salesTerritoryHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTerritoryHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4a3f2cf3792e41bfa96626a028525930</Hash>
</Codenesium>*/