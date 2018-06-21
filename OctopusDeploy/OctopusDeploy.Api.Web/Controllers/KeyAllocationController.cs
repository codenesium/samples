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
                        IKeyAllocationService keyAllocationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               keyAllocationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6fa0ae5c001113ea3f767b2fbef2c3c5</Hash>
</Codenesium>*/