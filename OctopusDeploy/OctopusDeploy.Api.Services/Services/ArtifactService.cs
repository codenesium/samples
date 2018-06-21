using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class ArtifactService : AbstractArtifactService, IArtifactService
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
                               dalartifactMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0af3f539d79c46b0d04ee5f36484d10d</Hash>
</Codenesium>*/