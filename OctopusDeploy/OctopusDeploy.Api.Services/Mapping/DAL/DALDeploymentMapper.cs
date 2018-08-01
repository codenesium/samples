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
    <Hash>1c3ae304f2fb5f0e1593ef8dd9f58276</Hash>
</Codenesium>*/