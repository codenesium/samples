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
    <Hash>f0e080a292a266b7f4e62b5a40ed789c</Hash>
</Codenesium>*/