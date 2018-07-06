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
        [Route("api/machines")]
        [ApiController]
        [ApiVersion("1.0")]
        public class MachineController : AbstractMachineController
        {
                public MachineController(
                        ApiSettings settings,
                        ILogger<MachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineService machineService,
                        IApiMachineModelMapper machineModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machineService,
                               machineModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c21226b7fb6aab57086e6f980e761a75</Hash>
</Codenesium>*/