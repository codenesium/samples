using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/stateProvinces")]
        [ApiVersion("1.0")]
        public class StateProvinceController: AbstractStateProvinceController
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
    <Hash>2d14dedff43e1d0c87fcf72a37abd617</Hash>
</Codenesium>*/