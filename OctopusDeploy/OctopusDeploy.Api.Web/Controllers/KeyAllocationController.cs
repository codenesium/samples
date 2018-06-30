using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/keyAllocations")]
        [ApiVersion("1.0")]
        public class KeyAllocationController : AbstractKeyAllocationController
        {
                public KeyAllocationController(
                        ApiSettings settings,
                        ILogger<KeyAllocationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IKeyAllocationService keyAllocationService,
                        IApiKeyAllocationModelMapper keyAllocationModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               keyAllocationService,
                               keyAllocationModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>953e94f3f0e4f77d8c75b03e10a02a18</Hash>
</Codenesium>*/