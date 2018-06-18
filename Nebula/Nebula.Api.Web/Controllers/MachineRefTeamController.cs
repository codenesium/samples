using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
        [Route("api/machineRefTeams")]
        [ApiVersion("1.0")]
        public class MachineRefTeamController: AbstractMachineRefTeamController
        {
                public MachineRefTeamController(
                        ApiSettings settings,
                        ILogger<MachineRefTeamController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineRefTeamService machineRefTeamService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machineRefTeamService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c8125e9749be8f1e24fc852a68322fd7</Hash>
</Codenesium>*/