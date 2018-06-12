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
        public class ProjectTriggerService: AbstractProjectTriggerService, IProjectTriggerService
        {
                public ProjectTriggerService(
                        ILogger<ProjectTriggerRepository> logger,
                        IProjectTriggerRepository projectTriggerRepository,
                        IApiProjectTriggerRequestModelValidator projectTriggerModelValidator,
                        IBOLProjectTriggerMapper bolprojectTriggerMapper,
                        IDALProjectTriggerMapper dalprojectTriggerMapper)
                        : base(logger,
                               projectTriggerRepository,
                               projectTriggerModelValidator,
                               bolprojectTriggerMapper,
                               dalprojectTriggerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d70dce6382875e00cf4044bffdcd9021</Hash>
</Codenesium>*/