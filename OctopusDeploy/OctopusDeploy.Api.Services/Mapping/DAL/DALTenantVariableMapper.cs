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
    <Hash>9ecb0fdbe5b476717c7850f45f23ad79</Hash>
</Codenesium>*/