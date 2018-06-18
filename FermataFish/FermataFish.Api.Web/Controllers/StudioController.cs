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
        [Route("api/studios")]
        [ApiVersion("1.0")]
        public class StudioController: AbstractStudioController
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
    <Hash>c8a9c233858bbb2edebe71d252e3fcfc</Hash>
</Codenesium>*/