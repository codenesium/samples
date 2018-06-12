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
        [Route("api/mutexes")]
        [ApiVersion("1.0")]
        public class MutexController: AbstractMutexController
        {
                public MutexController(
                        ServiceSettings settings,
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
    <Hash>ec53d522857351eb3d1e88f343d5abd5</Hash>
</Codenesium>*/