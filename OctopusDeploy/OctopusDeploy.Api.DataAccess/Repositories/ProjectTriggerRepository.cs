using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>19783f885de3c454ca198ff909fdb3c9</Hash>
</Codenesium>*/