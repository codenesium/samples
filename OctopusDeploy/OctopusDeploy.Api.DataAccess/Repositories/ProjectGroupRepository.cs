using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ProjectGroupRepository : AbstractProjectGroupRepository, IProjectGroupRepository
        {
                public ProjectGroupRepository(
                        ILogger<ProjectGroupRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8d210d67d651a602fec8ccc865be5ef6</Hash>
</Codenesium>*/