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
    <Hash>883f730e41550f990c0047a7997d55b8</Hash>
</Codenesium>*/