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
        [Route("api/teams")]
        [ApiVersion("1.0")]
        public class TeamController : AbstractTeamController
        {
                public TeamController(
                        ApiSettings settings,
                        ILogger<TeamController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeamService teamService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teamService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b9196c5963172c84b55f2e2b4b4768e9</Hash>
</Codenesium>*/