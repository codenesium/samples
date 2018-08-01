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
    <Hash>e8f9a5fb9fbd8a50f590028cffedafc9</Hash>
</Codenesium>*/