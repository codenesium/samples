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
                        ServiceSettings settings,
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
    <Hash>0ed2ca6263c894a3cc2dcae666581532</Hash>
</Codenesium>*/