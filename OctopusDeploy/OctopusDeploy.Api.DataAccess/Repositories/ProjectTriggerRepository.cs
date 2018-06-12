using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectTriggerRepository: AbstractProjectTriggerRepository, IProjectTriggerRepository
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
    <Hash>e16b35e9610d720e6c84d50bbd1a50e3</Hash>
</Codenesium>*/