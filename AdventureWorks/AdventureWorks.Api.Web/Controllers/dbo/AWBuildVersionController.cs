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
    <Hash>9b07d6dbca6bf565369032fd764d8356</Hash>
</Codenesium>*/