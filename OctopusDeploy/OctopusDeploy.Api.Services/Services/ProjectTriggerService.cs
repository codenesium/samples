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
                        ILogger<IProjectTriggerRepository> logger,
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
    <Hash>e9e8afa7b609f7d9f9daa596c118f932</Hash>
</Codenesium>*/