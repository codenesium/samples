using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public partial class OrganizationService : AbstractOrganizationService, IOrganizationService
	{
		public OrganizationService(
			ILogger<IOrganizationRepository> logger,
			IMediator mediator,
			IOrganizationRepository organizationRepository,
			IApiOrganizationServerRequestModelValidator organizationModelValidator,
			IDALOrganizationMapper dalOrganizationMapper,
			IDALTeamMapper dalTeamMapper)
			: base(logger,
			       mediator,
			       organizationRepository,
			       organizationModelValidator,
			       dalOrganizationMapper,
			       dalTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>068fc8569c028cd2cc58b9e7f2bceb3a</Hash>
</Codenesium>*/