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
        [Route("api/studios")]
        [ApiVersion("1.0")]
        public class StudioController : AbstractStudioController
        {
                public StudioController(
                        ApiSettings settings,
                        ILogger<StudioController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudioService studioService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               studioService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1a3133b13281ad182bb23a917ea2afd4</Hash>
</Codenesium>*/