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
        [Route("api/spaceXSpaceFeatures")]
        [ApiVersion("1.0")]
        public class SpaceXSpaceFeatureController: AbstractSpaceXSpaceFeatureController
        {
                public SpaceXSpaceFeatureController(
                        ServiceSettings settings,
                        ILogger<SpaceXSpaceFeatureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISpaceXSpaceFeatureService spaceXSpaceFeatureService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceXSpaceFeatureService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7de172d98855bdeaed809f243b5f1bcc</Hash>
</Codenesium>*/