using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALTenantVariableMapper : DALAbstractTenantVariableMapper, IDALTenantVariableMapper
	{
		public DALTenantVariableMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>de96d902594f3c4455c9f5a330a19a7f</Hash>
</Codenesium>*/