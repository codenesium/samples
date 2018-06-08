using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
        [Route("api/states")]
        [ApiVersion("1.0")]
        public class StateController: AbstractStateController
        {
                public StateController(
                        ServiceSettings settings,
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
    <Hash>4b2e1ef14b1330f76a135d9983550b1e</Hash>
</Codenesium>*/