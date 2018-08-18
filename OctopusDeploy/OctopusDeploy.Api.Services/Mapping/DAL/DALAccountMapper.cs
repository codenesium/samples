using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALAccountMapper : DALAbstractAccountMapper, IDALAccountMapper
	{
		public DALAccountMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9ce8bb52f4151867aaf923ef40215c1a</Hash>
</Codenesium>*/