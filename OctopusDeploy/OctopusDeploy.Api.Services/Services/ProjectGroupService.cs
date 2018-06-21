using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class ProjectGroupService : AbstractProjectGroupService, IProjectGroupService
        {
                public ProjectGroupService(
                        ILogger<IProjectGroupRepository> logger,
                        IProjectGroupRepository projectGroupRepository,
                        IApiProjectGroupRequestModelValidator projectGroupModelValidator,
                        IBOLProjectGroupMapper bolprojectGroupMapper,
                        IDALProjectGroupMapper dalprojectGroupMapper
                        )
                        : base(logger,
                               projectGroupRepository,
                               projectGroupModelValidator,
                               bolprojectGroupMapper,
                               dalprojectGroupMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f1bce1e37dd2434b4c68679132186966</Hash>
</Codenesium>*/