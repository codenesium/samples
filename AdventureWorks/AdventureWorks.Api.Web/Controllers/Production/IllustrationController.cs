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
        [Route("api/illustrations")]
        [ApiVersion("1.0")]
        public class IllustrationController : AbstractIllustrationController
        {
                public IllustrationController(
                        ApiSettings settings,
                        ILogger<IllustrationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IIllustrationService illustrationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               illustrationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d37c13772b52d58203a50ba77e340cf3</Hash>
</Codenesium>*/