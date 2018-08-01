using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>779709febf5ed516010ea44c28017e89</Hash>
</Codenesium>*/