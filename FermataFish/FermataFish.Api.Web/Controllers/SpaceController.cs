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
        [Route("api/spaces")]
        [ApiVersion("1.0")]
        public class SpaceController : AbstractSpaceController
        {
                public SpaceController(
                        ApiSettings settings,
                        ILogger<SpaceController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceService spaceService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>afd1f88c05dc1ecb26e74b343aac2664</Hash>
</Codenesium>*/