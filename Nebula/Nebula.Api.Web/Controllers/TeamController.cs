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
        [Route("api/teams")]
        [ApiVersion("1.0")]
        public class TeamController: AbstractTeamController
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
    <Hash>9f4f964fade089de2415bb413493d013</Hash>
</Codenesium>*/