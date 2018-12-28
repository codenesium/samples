using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>88da5656975bb5b036a482a272201803</Hash>
</Codenesium>*/