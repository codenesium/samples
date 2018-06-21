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
    <Hash>fc34206ad0cf97aca2dd818a6be38c3e</Hash>
</Codenesium>*/