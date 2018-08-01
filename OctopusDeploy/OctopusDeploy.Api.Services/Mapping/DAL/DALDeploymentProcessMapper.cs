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
    <Hash>12d1a5dd91156e297974eb5741ec542d</Hash>
</Codenesium>*/