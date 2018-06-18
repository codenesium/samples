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
        public class ServerTaskService: AbstractServerTaskService, IServerTaskService
        {
                public ServerTaskService(
                        ILogger<IServerTaskRepository> logger,
                        IServerTaskRepository serverTaskRepository,
                        IApiServerTaskRequestModelValidator serverTaskModelValidator,
                        IBOLServerTaskMapper bolserverTaskMapper,
                        IDALServerTaskMapper dalserverTaskMapper

                        )
                        : base(logger,
                               serverTaskRepository,
                               serverTaskModelValidator,
                               bolserverTaskMapper,
                               dalserverTaskMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c5e09c45edc440745d91e1005802fed7</Hash>
</Codenesium>*/