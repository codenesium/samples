using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IMediator mediator,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IDALAdminMapper dalAdminMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       mediator,
			       adminRepository,
			       adminModelValidator,
			       dalAdminMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7dc619aca65742369dfa03ad3f010ce8</Hash>
</Codenesium>*/