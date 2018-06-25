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
        public partial class ProjectTriggerService : AbstractProjectTriggerService, IProjectTriggerService
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
                               dalprojectTriggerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d1f583af9f64b5a71b9f6aa62eaefc4b</Hash>
</Codenesium>*/