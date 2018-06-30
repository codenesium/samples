using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ProjectRepository : AbstractProjectRepository, IProjectRepository
        {
                public ProjectRepository(
                        ILogger<ProjectRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>be8b59b0087834afd9a2714b16671a70</Hash>
</Codenesium>*/