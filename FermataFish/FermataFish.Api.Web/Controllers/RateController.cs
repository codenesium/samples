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
        [Route("api/rates")]
        [ApiVersion("1.0")]
        public class RateController: AbstractRateController
        {
                public RateController(
                        ServiceSettings settings,
                        ILogger<RateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IRateService rateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               rateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a139c478d7f985c55e0af1782b8b592b</Hash>
</Codenesium>*/