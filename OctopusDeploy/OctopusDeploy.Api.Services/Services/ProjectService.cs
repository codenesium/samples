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
        public partial class ProjectService : AbstractProjectService, IProjectService
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
    <Hash>60f10c0309fc3af64f94fbeffda78720</Hash>
</Codenesium>*/