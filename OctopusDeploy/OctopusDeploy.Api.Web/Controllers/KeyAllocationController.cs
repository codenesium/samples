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
                        ServiceSettings settings,
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
    <Hash>9b850e7b0de9803e7c0ff747398feb98</Hash>
</Codenesium>*/