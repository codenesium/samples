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
        [Route("api/cultures")]
        [ApiVersion("1.0")]
        public class CultureController: AbstractCultureController
        {
                public CultureController(
                        ServiceSettings settings,
                        ILogger<CultureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICultureService cultureService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               cultureService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5468940995c222bcb206d52adc2b6942</Hash>
</Codenesium>*/