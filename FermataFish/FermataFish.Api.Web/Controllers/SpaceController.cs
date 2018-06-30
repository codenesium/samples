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
                        ISpaceService spaceService,
                        IApiSpaceModelMapper spaceModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               spaceService,
                               spaceModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f6ce23537dcda3f4e9cb23c8a81ae8af</Hash>
</Codenesium>*/