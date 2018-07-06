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
        [Route("api/businessEntities")]
        [ApiController]
        [ApiVersion("1.0")]
        public class BusinessEntityController : AbstractBusinessEntityController
        {
                public BusinessEntityController(
                        ApiSettings settings,
                        ILogger<BusinessEntityController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityService businessEntityService,
                        IApiBusinessEntityModelMapper businessEntityModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityService,
                               businessEntityModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9c090b1d46c13b25b973eed6e75d4728</Hash>
</Codenesium>*/