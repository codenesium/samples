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
        [Route("api/aWBuildVersions")]
        [ApiController]
        [ApiVersion("1.0")]
        public class AWBuildVersionController : AbstractAWBuildVersionController
        {
                public AWBuildVersionController(
                        ApiSettings settings,
                        ILogger<AWBuildVersionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAWBuildVersionService aWBuildVersionService,
                        IApiAWBuildVersionModelMapper aWBuildVersionModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               aWBuildVersionService,
                               aWBuildVersionModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>94e34b8fc4aad9c7db399ea2066edd1f</Hash>
</Codenesium>*/