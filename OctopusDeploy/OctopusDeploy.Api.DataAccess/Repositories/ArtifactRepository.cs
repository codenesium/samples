using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ArtifactRepository : AbstractArtifactRepository, IArtifactRepository
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
    <Hash>68a018ba524ccbf9e9fb72e285c751a1</Hash>
</Codenesium>*/