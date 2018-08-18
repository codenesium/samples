using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALDeploymentHistoryMapper : DALAbstractDeploymentHistoryMapper, IDALDeploymentHistoryMapper
	{
		public DALDeploymentHistoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>870748e24c2ddbcefa0ccb9c0c08f740</Hash>
</Codenesium>*/