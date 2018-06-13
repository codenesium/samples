using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ArtifactService: AbstractArtifactService, IArtifactService
        {
                public ArtifactService(
                        ILogger<ArtifactRepository> logger,
                        IArtifactRepository artifactRepository,
                        IApiArtifactRequestModelValidator artifactModelValidator,
                        IBOLArtifactMapper bolartifactMapper,
                        IDALArtifactMapper dalartifactMapper

                        )
                        : base(logger,
                               artifactRepository,
                               artifactModelValidator,
                               bolartifactMapper,
                               dalartifactMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>08dc909302cabb5d2bc5aee79e580651</Hash>
</Codenesium>*/