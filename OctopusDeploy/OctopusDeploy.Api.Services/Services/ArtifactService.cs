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
                        ILogger<IArtifactRepository> logger,
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
    <Hash>682c7b1d50372081635113b364c22bec</Hash>
</Codenesium>*/