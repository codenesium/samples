using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class TeamService : AbstractTeamService, ITeamService
	{
		public TeamService(
			ILogger<ITeamRepository> logger,
			ITeamRepository teamRepository,
			IApiTeamServerRequestModelValidator teamModelValidator,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base(logger,
			       teamRepository,
			       teamModelValidator,
			       bolTeamMapper,
			       dalTeamMapper,
			       bolChainMapper,
			       dalChainMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bdb221275414ed00e017d77f427afe9b</Hash>
</Codenesium>*/