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
        [ApiController]
        [ApiVersion("1.0")]
        public class TeamController : AbstractTeamController
        {
                public TeamController(
                        ApiSettings settings,
                        ILogger<TeamController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeamService teamService,
                        IApiTeamModelMapper teamModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teamService,
                               teamModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4d50d1908126045e0c7fc8bada25fdc6</Hash>
</Codenesium>*/