using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectTriggerRepository : AbstractProjectTriggerRepository, IProjectTriggerRepository
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
    <Hash>d6698d15e66748e6aa6107eae212d81a</Hash>
</Codenesium>*/