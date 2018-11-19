using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper)
			: base(logger,
			       adminRepository,
			       adminModelValidator,
			       bolAdminMapper,
			       dalAdminMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>86513b8cd2c3b67558dbfbebd48f3374</Hash>
</Codenesium>*/