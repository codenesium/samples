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
        public class ProjectService: AbstractProjectService, IProjectService
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
                               dalprojectMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>014ca1c84d7765c4401af61b70acdadc</Hash>
</Codenesium>*/