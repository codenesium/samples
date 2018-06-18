using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/keyAllocations")]
        [ApiVersion("1.0")]
        public class KeyAllocationController: AbstractKeyAllocationController
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
    <Hash>7da4d5397f9f2bcbad2aedac90a006c9</Hash>
</Codenesium>*/