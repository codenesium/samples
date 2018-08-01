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
    <Hash>1b4b8af567a7a4cca93c9ccc03fb2464</Hash>
</Codenesium>*/