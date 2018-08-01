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
    <Hash>2498b8c99ca056ac9e765d0c866620a1</Hash>
</Codenesium>*/