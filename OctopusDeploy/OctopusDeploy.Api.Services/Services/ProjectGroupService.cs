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
                               dalprojectGroupMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2ad5eeb331562193506bec2ca2aa997e</Hash>
</Codenesium>*/