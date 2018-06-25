using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ProjectTriggerRepository : AbstractProjectTriggerRepository, IProjectTriggerRepository
        {
                public ProjectTriggerRepository(
                        ILogger<ProjectTriggerRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e6d7c7060fad8a27298ad46f80449f66</Hash>
</Codenesium>*/