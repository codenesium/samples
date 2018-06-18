using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/provinces")]
        [ApiVersion("1.0")]
        public class ProvinceController: AbstractProvinceController
        {
                public ProvinceController(
                        ApiSettings settings,
                        ILogger<ProvinceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProvinceService provinceService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               provinceService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4f7395d81cdeee5b3ea77ed0e7c1b2c6</Hash>
</Codenesium>*/