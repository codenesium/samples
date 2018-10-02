using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class DALTenantMapper : DALAbstractTenantMapper, IDALTenantMapper
	{
		public DALTenantMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b03d9d528f02357f6c75699e057cf051</Hash>
</Codenesium>*/