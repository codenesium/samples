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
                        IStateService stateService,
                        IApiStateModelMapper stateModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               stateService,
                               stateModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e6d9f7fb4d236a5276c9cb9edefc481f</Hash>
</Codenesium>*/