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
        public partial class TeamService : AbstractTeamService, ITeamService
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
                               dalteamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5d525ba7d110e0518703d76fe9302152</Hash>
</Codenesium>*/