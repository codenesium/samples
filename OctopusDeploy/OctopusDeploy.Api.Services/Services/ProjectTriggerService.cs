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
                        IDALProjectTriggerMapper dalprojectTriggerMapper

                        )
                        : base(logger,
                               projectTriggerRepository,
                               projectTriggerModelValidator,
                               bolprojectTriggerMapper,
                               dalprojectTriggerMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c83785aef368e095ca8d2f94e1db0681</Hash>
</Codenesium>*/