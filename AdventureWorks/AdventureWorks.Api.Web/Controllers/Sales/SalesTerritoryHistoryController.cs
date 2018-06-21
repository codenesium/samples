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
        [Route("api/salesTerritoryHistories")]
        [ApiVersion("1.0")]
        public class SalesTerritoryHistoryController : AbstractSalesTerritoryHistoryController
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
    <Hash>ca04dc426aef64cc2ee50f40ee1ce87a</Hash>
</Codenesium>*/