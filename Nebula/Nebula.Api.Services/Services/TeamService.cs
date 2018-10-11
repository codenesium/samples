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
			IDALChainMapper dalChainMapper)
			: base(logger,
			       teamRepository,
			       teamModelValidator,
			       bolteamMapper,
			       dalteamMapper,
			       bolChainMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d466f417d19b701a16c54c78594c474</Hash>
</Codenesium>*/