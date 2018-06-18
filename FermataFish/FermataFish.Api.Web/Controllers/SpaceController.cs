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
        [Route("api/spaces")]
        [ApiVersion("1.0")]
        public class SpaceController: AbstractSpaceController
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
    <Hash>00dc9d036cf96e6ccd634886f9962961</Hash>
</Codenesium>*/