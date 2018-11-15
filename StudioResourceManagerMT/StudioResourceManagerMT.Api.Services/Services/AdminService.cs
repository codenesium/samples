using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>6daa0b716ee96f537eb27dc3a2f98563</Hash>
</Codenesium>*/