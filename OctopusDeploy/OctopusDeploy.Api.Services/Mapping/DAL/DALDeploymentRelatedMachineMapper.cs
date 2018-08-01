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
    <Hash>02daf8a433204f2072a12ef2fb4ae23a</Hash>
</Codenesium>*/