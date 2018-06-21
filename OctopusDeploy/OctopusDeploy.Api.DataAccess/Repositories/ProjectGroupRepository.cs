using Codenesium.DataConversionExtensions;
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
    <Hash>386964a04b2c6a19f50bd5808bdab638</Hash>
</Codenesium>*/