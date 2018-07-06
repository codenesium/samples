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
        [ApiController]
        [ApiVersion("1.0")]
        public class StateProvinceController : AbstractStateProvinceController
        {
                public StateProvinceController(
                        ApiSettings settings,
                        ILogger<StateProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStateProvinceService stateProvinceService,
                        IApiStateProvinceModelMapper stateProvinceModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               stateProvinceService,
                               stateProvinceModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>75c961587510a85e285fe856394914c3</Hash>
</Codenesium>*/