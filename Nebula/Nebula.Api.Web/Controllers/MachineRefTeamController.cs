using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Web
{
        [Route("api/machineRefTeams")]
        [ApiVersion("1.0")]
        public class MachineRefTeamController : AbstractMachineRefTeamController
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
    <Hash>79624d7b8cbce888630071062aa0245a</Hash>
</Codenesium>*/