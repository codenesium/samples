using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/artifacts")]
        [ApiVersion("1.0")]
        public class ArtifactController: AbstractArtifactController
        {
                public ArtifactController(
                        ServiceSettings settings,
                        ILogger<ArtifactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IArtifactService artifactService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               artifactService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d61b9c90419f0403ddf0bbeef95f85fe</Hash>
</Codenesium>*/