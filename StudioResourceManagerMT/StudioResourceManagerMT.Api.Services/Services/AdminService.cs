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
    <Hash>763435249b1ba67238c407643c88271e</Hash>
</Codenesium>*/