using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALTeamMapper : DALAbstractTeamMapper, IDALTeamMapper
	{
		public DALTeamMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ecb071c713c3f1f156deb2841b16ad1d</Hash>
</Codenesium>*/