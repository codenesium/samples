using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial class OrganizationService : AbstractOrganizationService, IOrganizationService
	{
		public OrganizationService(
			ILogger<IOrganizationRepository> logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper bolorganizationMapper,
			IDALOrganizationMapper dalorganizationMapper,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper
			)
			: base(logger,
			       organizationRepository,
			       organizationModelValidator,
			       bolorganizationMapper,
			       dalorganizationMapper,
			       bolTeamMapper,
			       dalTeamMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b7f5e93b39f073c2c21eb72977850ab4</Hash>
</Codenesium>*/