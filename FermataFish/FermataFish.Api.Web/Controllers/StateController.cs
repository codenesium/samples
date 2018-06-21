using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
        [Route("api/states")]
        [ApiVersion("1.0")]
        public class StateController : AbstractStateController
        {
                public StateController(
                        ApiSettings settings,
                        ILogger<StateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStateService stateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               stateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ed3275f161229f48a0436a7339c8cc18</Hash>
</Codenesium>*/