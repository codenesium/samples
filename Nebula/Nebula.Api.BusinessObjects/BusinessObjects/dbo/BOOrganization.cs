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
			IOrganizationModelValidator organizationModelValidator)
			: base(logger, organizationRepository, organizationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>769c56a856a012c6710abc7cd8ad7e31</Hash>
</Codenesium>*/