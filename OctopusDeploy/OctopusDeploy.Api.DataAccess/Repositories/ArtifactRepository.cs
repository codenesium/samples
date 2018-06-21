using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>8e2ad8af7addccdef2cb4a12c039c069</Hash>
</Codenesium>*/