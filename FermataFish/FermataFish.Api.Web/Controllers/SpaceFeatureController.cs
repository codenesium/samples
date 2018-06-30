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
    <Hash>4068144c7f77bfa32db7162f72c8317d</Hash>
</Codenesium>*/