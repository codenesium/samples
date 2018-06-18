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
        [Route("api/stores")]
        [ApiVersion("1.0")]
        public class StoreController: AbstractStoreController
        {
                public StoreController(
                        ApiSettings settings,
                        ILogger<StoreController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStoreService storeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               storeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ba29c84eff4b8f4d066663c574103419</Hash>
</Codenesium>*/