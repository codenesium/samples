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
        [Route("api/spaceFeatures")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SpaceFeatureController : AbstractSpaceFeatureController
        {
                public SpaceFeatureController(
                        ApiSettings settings,
                        ILogger<SpaceFeatureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceFeatureService spaceFeatureService,
                        IApiSpaceFeatureModelMapper spaceFeatureModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceFeatureService,
                               spaceFeatureModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>32ceb158094b6ae8cf953780fa25f672</Hash>
</Codenesium>*/