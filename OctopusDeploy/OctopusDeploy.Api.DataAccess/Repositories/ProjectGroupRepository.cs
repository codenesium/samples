using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectGroupRepository : AbstractProjectGroupRepository, IProjectGroupRepository
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
    <Hash>4c3fc331253b61d40ab7fd04c241b92e</Hash>
</Codenesium>*/