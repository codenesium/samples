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
        public class ProjectService : AbstractProjectService, IProjectService
        {
                public ProjectService(
                        ILogger<IProjectRepository> logger,
                        IProjectRepository projectRepository,
                        IApiProjectRequestModelValidator projectModelValidator,
                        IBOLProjectMapper bolprojectMapper,
                        IDALProjectMapper dalprojectMapper
                        )
                        : base(logger,
                               projectRepository,
                               projectModelValidator,
                               bolprojectMapper,
                               dalprojectMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>71df75ff3199e6ecf45fb8a0d1b38682</Hash>
</Codenesium>*/