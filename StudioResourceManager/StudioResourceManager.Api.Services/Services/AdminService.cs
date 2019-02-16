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
			IDALAdminMapper dalAdminMapper)
			: base(logger,
			       mediator,
			       adminRepository,
			       adminModelValidator,
			       dalAdminMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>239b82dbf822f61c9a1395de4666cac2</Hash>
</Codenesium>*/