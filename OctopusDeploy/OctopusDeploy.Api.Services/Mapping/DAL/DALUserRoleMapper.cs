using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALUserRoleMapper : DALAbstractUserRoleMapper, IDALUserRoleMapper
	{
		public DALUserRoleMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b8e4fa62dfe0623c6a2010d6f9454bec</Hash>
</Codenesium>*/