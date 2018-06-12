using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ArtifactRepository: AbstractArtifactRepository, IArtifactRepository
        {
                public ArtifactRepository(
                        ILogger<ArtifactRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6cd1af024062c34f96bd1b0ba6b2e0a6</Hash>
</Codenesium>*/