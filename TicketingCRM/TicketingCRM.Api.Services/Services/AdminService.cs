using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class AdminService : AbstractAdminService, IAdminService
	{
		public AdminService(
			ILogger<IAdminRepository> logger,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       adminRepository,
			       adminModelValidator,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>749f517ca4ae5999662d74d8b327c2ed</Hash>
</Codenesium>*/