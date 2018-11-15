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
			IDALTeamMapper dalTeamMapper)
			: base(logger,
			       teamRepository,
			       teamModelValidator,
			       bolTeamMapper,
			       dalTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ec95121eaf3119428a2d000b2a8f7144</Hash>
</Codenesium>*/