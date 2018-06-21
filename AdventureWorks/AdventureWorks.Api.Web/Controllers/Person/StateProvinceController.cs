using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/stateProvinces")]
        [ApiVersion("1.0")]
        public class StateProvinceController : AbstractStateProvinceController
        {
                public StateProvinceController(
                        ApiSettings settings,
                        ILogger<StateProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStateProvinceService stateProvinceService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               stateProvinceService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d63bc192d49d4d6a9a50dc37b1d69ef0</Hash>
</Codenesium>*/