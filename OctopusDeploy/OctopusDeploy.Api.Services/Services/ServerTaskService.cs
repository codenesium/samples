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
                        ILogger<ServerTaskRepository> logger,
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
    <Hash>dae1576d6965234d5dfe298f4c205d3e</Hash>
</Codenesium>*/