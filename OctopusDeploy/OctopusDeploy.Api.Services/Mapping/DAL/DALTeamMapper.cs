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
    <Hash>2ce2b4135cca0b834bfd0609803f40d2</Hash>
</Codenesium>*/