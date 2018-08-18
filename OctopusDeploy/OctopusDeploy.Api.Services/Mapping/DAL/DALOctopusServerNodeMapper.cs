using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALOctopusServerNodeMapper : DALAbstractOctopusServerNodeMapper, IDALOctopusServerNodeMapper
	{
		public DALOctopusServerNodeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>820cc480b4142b21e07c83f47f71d5d1</Hash>
</Codenesium>*/