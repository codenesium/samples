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
        [Route("api/mutexes")]
        [ApiVersion("1.0")]
        public class MutexController : AbstractMutexController
        {
                public MutexController(
                        ApiSettings settings,
                        ILogger<MutexController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMutexService mutexService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               mutexService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ec5db33a44dc727762b867bcfdc5630f</Hash>
</Codenesium>*/