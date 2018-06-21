using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class TeamService : AbstractTeamService, ITeamService
        {
                public TeamService(
                        ILogger<ITeamRepository> logger,
                        ITeamRepository teamRepository,
                        IApiTeamRequestModelValidator teamModelValidator,
                        IBOLTeamMapper bolteamMapper,
                        IDALTeamMapper dalteamMapper,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper
                        )
                        : base(logger,
                               teamRepository,
                               teamModelValidator,
                               bolteamMapper,
                               dalteamMapper,
                               bolChainMapper,
                               dalChainMapper,
                               bolMachineRefTeamMapper,
                               dalMachineRefTeamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>35c38718478b49706e45b014586b6c18</Hash>
</Codenesium>*/