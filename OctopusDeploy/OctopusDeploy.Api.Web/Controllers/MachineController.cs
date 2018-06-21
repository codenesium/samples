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
        [ApiVersion("1.0")]
        public class MachineController : AbstractMachineController
        {
                public MachineController(
                        ApiSettings settings,
                        ILogger<MachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineService machineService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machineService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ccf315ec29c82d9f502124ce303fddae</Hash>
</Codenesium>*/