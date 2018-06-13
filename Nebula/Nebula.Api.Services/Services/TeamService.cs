using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class TeamService: AbstractTeamService, ITeamService
        {
                public TeamService(
                        ILogger<TeamRepository> logger,
                        ITeamRepository teamRepository,
                        IApiTeamRequestModelValidator teamModelValidator,
                        IBOLTeamMapper bolteamMapper,
                        IDALTeamMapper dalteamMapper
                        ,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper
                        ,
                        IBOLMachineRefTeamMapper bolMachineRefTeamMapper,
                        IDALMachineRefTeamMapper dalMachineRefTeamMapper

                        )
                        : base(logger,
                               teamRepository,
                               teamModelValidator,
                               bolteamMapper,
                               dalteamMapper
                               ,
                               bolChainMapper,
                               dalChainMapper
                               ,
                               bolMachineRefTeamMapper,
                               dalMachineRefTeamMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>0213f4cbfe78bc009170dd5730736296</Hash>
</Codenesium>*/