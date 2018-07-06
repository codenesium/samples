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
        [ApiController]
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
    <Hash>41fc42eaaaaccfba72ebef29ef71976f</Hash>
</Codenesium>*/