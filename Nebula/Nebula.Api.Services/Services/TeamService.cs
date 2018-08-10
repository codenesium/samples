using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class TeamService : AbstractTeamService, ITeamService
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
    <Hash>8a34f58b839eae51f1aa8c9d7e011337</Hash>
</Codenesium>*/