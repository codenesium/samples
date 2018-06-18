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
                        ILogger<ITeamRepository> logger,
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
    <Hash>4bcd57699efe7bd92acc532c6ab7ac75</Hash>
</Codenesium>*/