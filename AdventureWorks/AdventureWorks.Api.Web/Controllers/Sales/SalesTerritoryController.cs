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
        [Route("api/salesTerritories")]
        [ApiVersion("1.0")]
        public class SalesTerritoryController: AbstractSalesTerritoryController
        {
                public SalesTerritoryController(
                        ApiSettings settings,
                        ILogger<SalesTerritoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTerritoryService salesTerritoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTerritoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c8deba7a7f0676a859f49d69cf9d907c</Hash>
</Codenesium>*/