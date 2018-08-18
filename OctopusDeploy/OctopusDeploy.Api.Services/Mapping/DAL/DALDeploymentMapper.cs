using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALDeploymentMapper : DALAbstractDeploymentMapper, IDALDeploymentMapper
	{
		public DALDeploymentMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e1e855e08fa180d647dd8d49bc9adc7f</Hash>
</Codenesium>*/