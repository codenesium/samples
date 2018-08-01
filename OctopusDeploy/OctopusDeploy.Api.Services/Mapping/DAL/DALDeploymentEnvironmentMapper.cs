using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALDeploymentEnvironmentMapper : DALAbstractDeploymentEnvironmentMapper, IDALDeploymentEnvironmentMapper
	{
		public DALDeploymentEnvironmentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>03abbd739c8cd9773c2f63be52ca9ca8</Hash>
</Codenesium>*/