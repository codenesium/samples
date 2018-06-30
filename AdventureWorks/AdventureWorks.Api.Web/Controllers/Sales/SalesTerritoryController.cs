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
        [Route("api/salesTerritories")]
        [ApiVersion("1.0")]
        public class SalesTerritoryController : AbstractSalesTerritoryController
        {
                public SalesTerritoryController(
                        ApiSettings settings,
                        ILogger<SalesTerritoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTerritoryService salesTerritoryService,
                        IApiSalesTerritoryModelMapper salesTerritoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTerritoryService,
                               salesTerritoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6a063831ee5d636542094b221d5b862e</Hash>
</Codenesium>*/