using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectGroupRepository: AbstractProjectGroupRepository, IProjectGroupRepository
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
    <Hash>5e5e25b092dc302d34edb599f5bf89eb</Hash>
</Codenesium>*/