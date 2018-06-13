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
        public class TeamService: AbstractTeamService, ITeamService
        {
                public TeamService(
                        ILogger<TeamRepository> logger,
                        ITeamRepository teamRepository,
                        IApiTeamRequestModelValidator teamModelValidator,
                        IBOLTeamMapper bolteamMapper,
                        IDALTeamMapper dalteamMapper

                        )
                        : base(logger,
                               teamRepository,
                               teamModelValidator,
                               bolteamMapper,
                               dalteamMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>61eaf610f6745f3cdf383650f1c5ca8a</Hash>
</Codenesium>*/