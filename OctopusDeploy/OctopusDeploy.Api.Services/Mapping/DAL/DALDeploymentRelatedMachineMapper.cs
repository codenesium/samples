using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALDeploymentRelatedMachineMapper : DALAbstractDeploymentRelatedMachineMapper, IDALDeploymentRelatedMachineMapper
	{
		public DALDeploymentRelatedMachineMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>32f01a6e96c2072d0c3cd5489fb97264</Hash>
</Codenesium>*/