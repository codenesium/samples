using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALTenantMapper : DALAbstractTenantMapper, IDALTenantMapper
	{
		public DALTenantMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6056205427c6c332d2553155f36c688e</Hash>
</Codenesium>*/