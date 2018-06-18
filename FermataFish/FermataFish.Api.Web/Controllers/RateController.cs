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
                        ApiSettings settings,
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
    <Hash>d26726116c2f62e989b2920766d98c0c</Hash>
</Codenesium>*/