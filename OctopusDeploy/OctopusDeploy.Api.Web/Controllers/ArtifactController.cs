using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/artifacts")]
        [ApiVersion("1.0")]
        public class ArtifactController : AbstractArtifactController
        {
                public ArtifactController(
                        ApiSettings settings,
                        ILogger<ArtifactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IArtifactService artifactService,
                        IApiArtifactModelMapper artifactModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               artifactService,
                               artifactModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0613b33a401541f164158180dd8d2088</Hash>
</Codenesium>*/