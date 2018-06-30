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
    <Hash>3bc21b49b39b214884f97853c82e36bf</Hash>
</Codenesium>*/