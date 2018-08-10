using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b2fc2b788d1a5facac08f59f29dc5810</Hash>
</Codenesium>*/