using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ProjectGroupService: AbstractProjectGroupService, IProjectGroupService
        {
                public ProjectGroupService(
                        ILogger<ProjectGroupRepository> logger,
                        IProjectGroupRepository projectGroupRepository,
                        IApiProjectGroupRequestModelValidator projectGroupModelValidator,
                        IBOLProjectGroupMapper bolprojectGroupMapper,
                        IDALProjectGroupMapper dalprojectGroupMapper

                        )
                        : base(logger,
                               projectGroupRepository,
                               projectGroupModelValidator,
                               bolprojectGroupMapper,
                               dalprojectGroupMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>bbce90158d3502a4f0f3b5618e4e6e47</Hash>
</Codenesium>*/