using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ArtifactRepository : AbstractArtifactRepository, IArtifactRepository
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
    <Hash>f180f4605ac303f5c82ae28578731863</Hash>
</Codenesium>*/