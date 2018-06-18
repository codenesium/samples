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
        [Route("api/businessEntities")]
        [ApiVersion("1.0")]
        public class BusinessEntityController: AbstractBusinessEntityController
        {
                public BusinessEntityController(
                        ApiSettings settings,
                        ILogger<BusinessEntityController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityService businessEntityService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9b47c35ab883a728c29e4bde727699ca</Hash>
</Codenesium>*/