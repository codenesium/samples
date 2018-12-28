using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IMediator mediator,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper)
			: base(logger,
			       mediator,
			       adminRepository,
			       adminModelValidator,
			       bolAdminMapper,
			       dalAdminMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca82078d3bb3d24c68d4df141578946a</Hash>
</Codenesium>*/