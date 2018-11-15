using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class OrganizationService : AbstractOrganizationService, IOrganizationService
	{
		public OrganizationService(
			ILogger<IOrganizationRepository> logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationServerRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper bolOrganizationMapper,
			IDALOrganizationMapper dalOrganizationMapper,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper)
			: base(logger,
			       organizationRepository,
			       organizationModelValidator,
			       bolOrganizationMapper,
			       dalOrganizationMapper,
			       bolTeamMapper,
			       dalTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a0137a57c621bbffd9805c97883f6a90</Hash>
</Codenesium>*/