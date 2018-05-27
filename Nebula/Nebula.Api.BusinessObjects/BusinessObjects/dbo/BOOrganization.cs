using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class BOOrganization: AbstractBOOrganization, IBOOrganization
	{
		public BOOrganization(
			ILogger<OrganizationRepository> logger,
			IOrganizationRepository organizationRepository,
			IApiOrganizationRequestModelValidator organizationModelValidator,
			IBOLOrganizationMapper organizationMapper)
			: base(logger, organizationRepository, organizationModelValidator, organizationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a975e0ecbf7dcaad1b539e8be17d20fc</Hash>
</Codenesium>*/