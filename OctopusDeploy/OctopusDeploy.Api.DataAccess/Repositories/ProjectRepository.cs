using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectRepository : AbstractProjectRepository, IProjectRepository
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
    <Hash>b9c0102d94a6bc476032b14f95de5e50</Hash>
</Codenesium>*/