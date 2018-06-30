using Codenesium.DataConversionExtensions;
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
        public partial class ProjectGroupService : AbstractProjectGroupService, IProjectGroupService
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
    <Hash>d3e89e43cd8607f32b1b7c5e167b6fda</Hash>
</Codenesium>*/