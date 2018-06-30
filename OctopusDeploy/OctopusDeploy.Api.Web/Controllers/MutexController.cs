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
                        IMutexService mutexService,
                        IApiMutexModelMapper mutexModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               mutexService,
                               mutexModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>412c6c9ec3ac73597db6f6266b8f106d</Hash>
</Codenesium>*/