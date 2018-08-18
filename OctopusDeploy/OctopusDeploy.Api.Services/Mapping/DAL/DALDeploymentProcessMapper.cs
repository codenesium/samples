using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALDeploymentProcessMapper : DALAbstractDeploymentProcessMapper, IDALDeploymentProcessMapper
	{
		public DALDeploymentProcessMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7f534106756f3dbf69fe16ce63f22819</Hash>
</Codenesium>*/