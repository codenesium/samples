using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ProjectRepository: AbstractProjectRepository, IProjectRepository
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
    <Hash>19bc5fb442f9abaa70275d34f8641ecc</Hash>
</Codenesium>*/