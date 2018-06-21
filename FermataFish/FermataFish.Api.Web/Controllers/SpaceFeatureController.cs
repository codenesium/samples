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
        [ApiVersion("1.0")]
        public class SpaceFeatureController : AbstractSpaceFeatureController
        {
                public SpaceFeatureController(
                        ApiSettings settings,
                        ILogger<SpaceFeatureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceFeatureService spaceFeatureService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceFeatureService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>dd7d8e75f93989108bb6892f18849088</Hash>
</Codenesium>*/