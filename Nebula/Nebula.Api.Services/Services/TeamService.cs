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
			IBOLTeamMapper BOLteamMapper,
			IDALTeamMapper DALteamMapper)
			: base(logger, teamRepository,
			       teamModelValidator,
			       BOLteamMapper,
			       DALteamMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>8e2ff1ee4ae39717a5c1e1d30645f263</Hash>
</Codenesium>*/